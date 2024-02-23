namespace MyBoards.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }   
        public DateTime CreatedDate { get; set; }   
        public DateTime? UpdatedDate { get; set;}
        public Workitem Workitem { get; set; }

        public int WorkItemId { get; set; } //klucz obcy typ na postawie klucza głównego 

    }
}
