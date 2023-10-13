using Microsoft.EntityFrameworkCore;
using OTD.Core.Entities;

namespace OTD.Repository.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
