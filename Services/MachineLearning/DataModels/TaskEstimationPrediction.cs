using Microsoft.ML.Data;

namespace Services.MachineLearning.DataModels
{
    public class TaskEstimationPrediction
    {
        [ColumnName("Score")]
        public float NumberOfDaysActual { get; set; }
    }
}
