using Microsoft.ML.Data;

namespace Services.MachineLearning.DataModels
{
    public class TaskData
    {
        [LoadColumn(0)]
        public float UserInChargeEfficiency { get; set; }

        [LoadColumn(1)]
        public float UserReportToEfficiency { get; set; }

        [LoadColumn(2)]
        public float TotalPoint { get; set; }

        [LoadColumn(3)]
        public float NumberOfDaysActual { get; set; }
    }
}
