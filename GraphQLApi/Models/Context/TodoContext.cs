using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Models.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Tasks { get; set; }
    }
}
