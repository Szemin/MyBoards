namespace MyBoards.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<Workitem> WorkItems { get; set; }
        //public List<WorkItemTag> WorkItemTags { get; set; } = new List<WorkItemTag>();
    }
}
