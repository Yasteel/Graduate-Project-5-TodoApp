namespace Todo.Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using Todo.Api.Models;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Todos> Todo { get; set; }

        DbSet<Tasks> Tasks { get; set; }
    }
}
