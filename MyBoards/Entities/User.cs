﻿namespace MyBoards.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Address Adress { get; set; }
        public List<Workitem> Workitems { get; set; } = new List<Workitem>();

        public List<Comment> Comments { get; set; } = new();
    }
}
