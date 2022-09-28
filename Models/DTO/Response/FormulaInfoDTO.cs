namespace Models.DTO.Response
{
    public class FormulaInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> InputNames { get; set; }
        public List<string> ConstantNames { get; set; }
        public string Define { get; set; }
        public string Description { get; set; }
    }
}
