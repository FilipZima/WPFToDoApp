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
    }
}
