namespace Services.SalaryManagement.Exporters
{
    public class Exporter
    {
        protected const int START_ROW = 1;
        protected const int START_COLUMN = 1;

        public string GetSavedpath(string prefix, int payslipId)
        {
            return $"{Directory.GetCurrentDirectory()}\\Report\\{prefix}_{payslipId}.xlsm";
        }
    }
}
