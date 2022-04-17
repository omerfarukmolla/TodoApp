using Microsoft.EntityFrameworkCore;
using OFM.TodoApp.DataAccess.Configurations;
using OFM.TodoApp.Entities.Domains;

namespace OFM.TodoApp.DataAccess.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            
        }
        public DbSet<Work> Works { get; set; }
    }
}
