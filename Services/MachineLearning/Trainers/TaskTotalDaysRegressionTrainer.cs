using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;

namespace Services.MachineLearning.Trainers
{
    public class TaskTotalDaysRegressionTrainer: TrainerBase<FastForestRegressionModelParameters>
    {
        public TaskTotalDaysRegressionTrainer() : base()
        {
            _model = MlContext.Regression.Trainers.FastForest();
        }
    }
}
