using Microsoft.EntityFrameworkCore;
namespace Mostra.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {
        }
        public DbSet<mostra> cadastro { get; set; }
        internal bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}