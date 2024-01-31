using Microsoft.EntityFrameworkCore;

namespace MyBoards.Entities
{
    public class MyBoardContext : DbContext
    {
        public MyBoardContext(DbContextOptions<MyBoardContext> options) : base(options)
        {
                
        }
        public DbSet<Workitem> Workitems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasKey(x => new { x.Email, x.LastName});               
        //} just in case how to create complex primary key (złożony klucz główny)
    }
   
}
