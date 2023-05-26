using Microsoft.ML;
using Microsoft.ML.Data;
using Services.MachineLearning.DataModels;

namespace Services.MachineLearning.Trainers
{
    public interface ITrainerBase
    {
        string Name { get; }
        ITransformer Fit(IEnumerable<TaskData> data);
        RegressionMetrics Evaluate();
    }
}
