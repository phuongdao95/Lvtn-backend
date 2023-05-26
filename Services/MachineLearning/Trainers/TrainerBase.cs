using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Services.MachineLearning.DataModels;

namespace Services.MachineLearning.Trainers
{
    public abstract class TrainerBase<TParameters> : ITrainerBase
        where TParameters : class
    {
        public string Name { get; protected set; }

        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, "regression.mdl");

        protected readonly MLContext MlContext;

        protected DataOperationsCatalog.TrainTestData _dataSplit;
        protected ITrainerEstimator<RegressionPredictionTransformer<TParameters>, TParameters> _model;
        protected ITransformer _trainedModel;

        protected TrainerBase()
        {
            MlContext = new MLContext(111);
        }

        public ITransformer Fit(IEnumerable<TaskData> taskData)
        {
            _dataSplit = LoadAndPrepareData(taskData);
            var dataProcessPipeline = BuildDataProcessingPipeline();
            var trainingPipeline = dataProcessPipeline.Append(_model);

            return trainingPipeline.Fit(_dataSplit.TrainSet);
        }

        public RegressionMetrics Evaluate()
        {
            var testSetTransform = _trainedModel.Transform(_dataSplit.TestSet);

            return MlContext.Regression.Evaluate(testSetTransform);
        }

        public void Save()
        {
            MlContext.Model.Save(_trainedModel, _dataSplit.TrainSet.Schema, ModelPath);
        }

        private EstimatorChain<NormalizingTransformer> BuildDataProcessingPipeline()
        {
            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(TaskData.NumberOfDaysActual))
                .Append(MlContext.Transforms.Concatenate("Features",
                                                nameof(TaskData.TotalPoint),
                                                nameof(TaskData.UserReportToEfficiency),
                                                nameof(TaskData.UserInChargeEfficiency),
                                                nameof(TaskData.NumberOfDaysActual)))
                .Append(MlContext.Transforms.NormalizeLogMeanVariance("Features", "Features"))
                .AppendCacheCheckpoint(MlContext);

            return dataProcessPipeline;
        }

        private DataOperationsCatalog.TrainTestData LoadAndPrepareData(IEnumerable<TaskData> taskData)
        {
            var trainingDataView = MlContext.Data.LoadFromEnumerable(taskData);
            return MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);
        }
    }

}

