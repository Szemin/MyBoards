using Microsoft.EntityFrameworkCore;

namespace MyBoards.Entities
{
    public class MyBoardContext : DbContext
    {
        /// <summary>
        /// przekazanie obiektu typu DbContextOptions dla klasy MyBoardContext wywołując konstruktor bazowy z tymi opcjami
        /// </summary>
        /// <param name="options"></param>
        public MyBoardContext(DbContextOptions<MyBoardContext> options) : base(options)
        {
                
        }
        public DbSet<Workitem> Workitems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Workitem>(eb =>
            {
                eb.Property(wi => wi.State).IsRequired();
                eb.Property(wi => wi.Area).HasColumnType("Varchar(200)");
                eb.Property(wi => wi.IterationPath).HasColumnName("Iteration_Path");
                eb.Property(wi => wi.EndDate).HasPrecision(3);
                eb.Property(wi => wi.Efford).HasColumnType("decimal(5,2)");
                eb.Property(wi => wi.Activity).HasMaxLength(200);
                eb.Property(wi => wi.RemainingWork).HasPrecision(14,2);
                eb.Property(wi => wi.Priority).HasDefaultValue(1);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()"); //auto przypis i default ustawiane przez serwer sql
                eb.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate(); //update gdy jest zmiana w encji
                
            });

            modelBuilder.Entity<User>()
                 .HasOne(u => u.Adress)
                 .WithOne(a => a.User)
                 .HasForeignKey<Address>(a => a.UserId);
        }

        #region complex primary
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasKey(x => new { x.Email, x.LastName});               
        //} just in case how to create complex primary key (złożony klucz główny)
        #endregion

    }

}
