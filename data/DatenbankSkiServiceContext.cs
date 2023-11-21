using Microsoft.EntityFrameworkCore;
using SkiServiceDatenbank.models;

namespace SkiServiceDatenbank.data
{
    public class DatenbankSkiServiceContext : DbContext
    {
        public DatenbankSkiServiceContext(DbContextOptions<DatenbankSkiServiceContext> options)
            : base(options)
        {
        }

        public DbSet<SkiService> SkiServices { get; set; }
    }
}
