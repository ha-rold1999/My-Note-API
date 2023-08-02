using Microsoft.EntityFrameworkCore;

namespace My_Note_API.EntityFramwork
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}
        public DbSet<Note> Notes { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Archive_ToDo> Archive_ToDos { get; set; }
    }
}
