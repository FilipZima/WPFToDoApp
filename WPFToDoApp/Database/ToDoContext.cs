using Microsoft.EntityFrameworkCore;
using WPFToDoApp.Models;

namespace WPFToDoApp.Database
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoEntity> ToDoSet { get; set; }

        public ToDoContext() 
        { 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = ToDoAppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoEntity>().HasData(
                new ToDoEntity { ID = 1, IsDone = true, Title = "Vyluxovat" },
                new ToDoEntity { ID = 2, IsDone = false, Title = "Nakoupit" }
                );
        }
    }
}
