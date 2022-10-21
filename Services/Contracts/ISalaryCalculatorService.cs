using Models.DTO.Request;

namespace Services.Contracts
{
    public interface ISalaryCalculatorService
    {
        void CalculateSalaryAndWritePayslipsIntoDatabase(PayrollDTO payrollDTO);
    }
}
