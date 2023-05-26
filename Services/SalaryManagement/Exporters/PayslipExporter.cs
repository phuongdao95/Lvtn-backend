using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.SalaryManagement.Exporters
{
    public class PayslipExporter : Exporter
    {
        private EmsContext _databaseContext;

        public PayslipExporter(EmsContext emsContext)
        {
            _databaseContext = emsContext;
        }

        public byte[] Export(int payslipId)
        {
            using (var workbook = new XLWorkbook())
            {
                var overviewSheet = workbook.Worksheets.Add("Khái quát");
                var timekeepingSheet = workbook.Worksheets.Add("Chấm công");
                var dabSheet = workbook.Worksheets.Add("Khấu trừ, phụ cấp, thưởng");

                var payslip = loadPayslip(payslipId);
                populateOvierviewSheet(payslip, overviewSheet);
                populateTimekeepingSheet(payslip, timekeepingSheet);
                populateDabSheet(payslip, dabSheet);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        private Payslip loadPayslip(int payslipId)
        {
            var payslip = _databaseContext.Payslips.Where(p => payslipId == p.Id)
                .Include(p => p.Timekeepings)
                .Include(p => p.SalaryDeltas)
                .Include(p => p.Employee)
                .FirstOrDefault();

            if (payslip is null)
            {
                throw new Exception("Payslip not found");
            }

            return payslip;
        }


        private void populateOvierviewSheet(Payslip payslip, IXLWorksheet worksheet)
        {

            int rowIndex = START_ROW, columnIndex = START_COLUMN;

            var columnNames = new List<string>
            {
                "Id", "Tên nhân viên", "Tên payslip", "Lương cơ bản", "Tổng khấu trừ", "Tổng thưởng", "Tổng phụ cấp",
                "Công thức áp dụng", "Mô tả", "Tháng",  "Tổng phụ cấp", "Lương thực tế"
            };

            foreach (var column in columnNames)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = column;
            }

            rowIndex++;
            columnIndex = START_COLUMN;

            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Id;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Employee?.Name;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Name;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.BaseSalary;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalDeduction;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalAllowance;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalBonus;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.FormulaDefine;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Description;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.SalaryAfterTimekeeepingCalculation;
            worksheet.Cell(rowIndex, columnIndex++).Value = payslip.ActualSalary;
        }

        private void populateTimekeepingSheet(Payslip payslip, IXLWorksheet worksheet)
        {
            int rowIndex = START_ROW, columnIndex = START_COLUMN;

            var timeKeepings = payslip.Timekeepings;

            var columnNames = new List<string>
            {
                "Id", "Ngày", "Bắt đầu", "Kết thúc", "Đã checkin", "Thời gian check in", "Đã checkout", "Thời gian check out",
                "Loại ca", "Tiền công", "Công thức"
            };

            foreach (var column in columnNames)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = column;
            }

            ++rowIndex;
            columnIndex = START_COLUMN;

            foreach (PayslipWorkingShiftTimekeeping timekeeping in timeKeepings)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.Id;
                worksheet.Cell(rowIndex, columnIndex++).Value = $"{timekeeping.StartTime.Value.Month} {timekeeping.StartTime.Value.Year}";
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.StartTime.Value.ToString();
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.EndTime.Value.ToString();
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.DidCheckIn;
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.CheckinTime;
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.DidCheckout;
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.CheckoutTime;
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.Type.ToString();
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.Amount;
                worksheet.Cell(rowIndex, columnIndex++).Value = timekeeping.FormulaDefine;

                ++rowIndex;
                columnIndex = START_COLUMN;
            }
        }

        private void populateDabSheet(Payslip payslip, IXLWorksheet worksheet)
        {
            var salaryDeltas = payslip.SalaryDeltas;

            int rowIndex = START_ROW, columnIndex = START_COLUMN;
            var columnNames = new List<string>
            {
                "Id", "Tên", "Loại", "Giá trị", "Công thức", "Group áp dụng", "Group Id",
                "Tháng bắt đầu", "Tháng kết thúc"
            };


            foreach (var column in columnNames)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = column;
            }

            ++rowIndex;
            columnIndex = START_COLUMN;

            foreach (var salaryDelta in salaryDeltas)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.Id;
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.Name;
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.SalaryDeltaType.ToString();
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.Amount;
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.FormulaDefine;
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.GroupName;
                worksheet.Cell(rowIndex, columnIndex++).Value = salaryDelta.GroupId;
                worksheet.Cell(rowIndex, columnIndex++).Value = $"{salaryDelta.FromMonth.Month}/{salaryDelta.FromMonth.Year}";
                worksheet.Cell(rowIndex, columnIndex++).Value = $"{salaryDelta.ToMonth.Month}/{salaryDelta.ToMonth.Year}";

                columnIndex = START_COLUMN;
                rowIndex++;
            }
        }
    }
}