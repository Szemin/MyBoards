﻿namespace MyBoards.Entities
{
    public class WorkItemTag
    {

        public Workitem Workitem { get; set; }
        public int WorkItemId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }

    }
}
