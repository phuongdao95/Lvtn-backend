namespace Models.DTO.Request
{
    public class FormulaInputDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? Description { get; set; }
    }
}
