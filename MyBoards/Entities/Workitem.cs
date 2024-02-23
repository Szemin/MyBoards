using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MyBoards.Entities
{
    
    public class Workitem
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public string IterationPath { get; set; }
        public int Priority { get; set; }
        //Epic
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // Issue
        public decimal Efford { get; set; }
        // Task  
        public string Activity { get; set; }
        public decimal RemainingWork { get; set; }
        public string Type { get; set; }

        public List<Comment> Comments { get; set; } = new();
        public User Auuthor { get; set; }
        public Guid AuthoID { get; set; }
        public List<WorkItemTag> WorkItemTags { get; set; } = new List<WorkItemTag>();


    }
    
}
