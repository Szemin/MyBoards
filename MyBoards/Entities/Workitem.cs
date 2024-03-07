using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MyBoards.Entities
{
    public class Epic : Workitem
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class Issue : Workitem 
    {
        
        public decimal Efford { get; set; }
    }
    public class Task : Workitem 
    { 
        public string Activity { get; set; }
        public decimal RemainingWork { get; set; }
    }
    public abstract class Workitem
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string IterationPath { get; set; }
        public int Priority { get; set; }       

        public List<Comment> Comments { get; set; } = new();
        public User Author { get; set; }
        public Guid AuthorID { get; set; }
        public List<Tag> Tags { get; set; }
        //public List<WorkItemTag> WorkItemTags { get; set; } = new List<WorkItemTag>();

        public State State { get; set; }
        public int StateId { get; set; }

    }
    
}
