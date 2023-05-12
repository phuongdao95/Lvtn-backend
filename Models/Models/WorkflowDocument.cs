namespace Models.Models
{
    public class WorkflowDocument
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int WorkflowId { get; set; }

        public Workflow? Workflow { get; set; }
    }
}
