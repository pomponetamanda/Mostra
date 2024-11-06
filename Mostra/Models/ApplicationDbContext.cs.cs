using Microsoft.EntityFrameworkCore;
namespace Mostra.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {
        }
        public DbSet<mostra> clientes { get; set; }
        internal bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}