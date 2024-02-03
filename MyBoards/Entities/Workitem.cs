using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MyBoards.Entities
{
    
    public class Workitem
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Area { get; set; }

        [Column("Iteration_Path")]
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


    }
    
}
