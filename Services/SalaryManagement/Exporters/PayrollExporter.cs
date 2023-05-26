using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.Models;
using Models.Repositories.DataContext;
using System.Drawing.Text;

namespace Services.SalaryManagement.Exporters
{
    public class PayrollExporter : Exporter
    {
        private EmsContext _databaseContext;

        public PayrollExporter(EmsContext emsContext)
        {
            _databaseContext = emsContext;
        }

        public byte[] Export(int payrollId)
        {
            var payroll = loadPayroll(payrollId);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add();
                populateData(payroll, worksheet);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        private Payroll loadPayroll(int payrollId)
        {
            var payroll = _databaseContext.Payrolls
                .Where(payroll => payroll.Id == payrollId)
                .Include(payroll => payroll.PayslipList)
                    .ThenInclude(payslip => payslip.Employee)
                .FirstOrDefault();

            if (payroll is null)
            {
                throw new Exception("Payroll is null");
            }

            return payroll;
        }


        private void populateData(Payroll payroll, IXLWorksheet worksheet)
        {
            if (payroll.PayslipList is null)
            {
                throw new Exception("payroll may not be null");
            }

            var columNames = new List<string>()
            {
                "Id", "Tên", "Mô tả", "Tên nhân viên", "Lương cơ bản", "Lương thực tế",
                "Tổng khấu trừ", "Tổng phụ cấp", "Tổng thưởng", "Công thức",
                "Tháng", "Mô tả"
            };

            int rowIndex = START_ROW, columnIndex = START_COLUMN;

            foreach (var name in columNames)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = name;
            }

            ++rowIndex;
            columnIndex = START_COLUMN;

            foreach (var payslip in payroll.PayslipList)
            {
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Id;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Name;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Description;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.Employee.Name;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.BaseSalary;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.ActualSalary;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalAllowance;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalDeduction;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.TotalBonus;
                worksheet.Cell(rowIndex, columnIndex++).Value = payslip.FormulaDefine;
                worksheet.Cell(rowIndex, columnIndex++).Value = $"{payslip.Month}/{payslip.Year}";

                ++rowIndex;
                columnIndex = START_COLUMN;
            }
        }

    }
}
