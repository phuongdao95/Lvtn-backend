namespace Models.DTO.Request.WorkflowConfigsDTO
{
    public class NghiPhepConfigRequest
    {
        public List<int> DepartmentIds { get; set; }
        public List<int> UserIds { get; set; }
        public bool IsSequence { get; set; }
        public int Minimum { get; set; }
        public int LongHolidaySet { get; set; }
        public int OverDay { get; set; }
    }
}
