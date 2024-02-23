namespace MyBoards.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Address Adress { get; set; }
        public List<Workitem> Workitem { get; set; } = new List<Workitem>();

    }
}
