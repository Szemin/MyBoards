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
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Epic>()
                .Property(wi => wi.EndDate)
                .HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(wi => wi.Activity)
                .HasMaxLength(200);

            modelBuilder.Entity<Task>()
                .Property(wi => wi.RemainingWork)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Issue>()
                .Property(wi => wi.Efford)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Workitem>(eb =>
            {
                eb.HasOne(w => w.State)
                .WithMany()
                .HasForeignKey(w => w.StateId);

                eb.Property(wi => wi.Area).HasColumnType("Varchar(200)");
                eb.Property(wi => wi.IterationPath).HasColumnName("Iteration_Path");                 
                eb.Property(wi => wi.Priority).HasDefaultValue(1);
                eb.HasMany(w => w.Comments)
                .WithOne(c => c.Workitem)
                .HasForeignKey(c => c.WorkItemId);

                eb.HasOne(w => w.Author)
                .WithMany(u => u.Workitems)
                .HasForeignKey(w => w.AuthorID);

                eb.HasMany(w => w.Tags)
                .WithMany(a => a.WorkItems)
                .UsingEntity<WorkItemTag>(
                    w => w.HasOne(wit => wit.Tag)
                    .WithMany()
                    .HasForeignKey(wit => wit.TagId),

                    w => w.HasOne(wit => wit.Workitem)
                    .WithMany()
                    .HasForeignKey(wit => wit.WorkItemId),

                    wit =>
                    {
                        wit.HasKey(x => new { x.TagId, x.WorkItemId });
                        wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                    }
                    );                
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
