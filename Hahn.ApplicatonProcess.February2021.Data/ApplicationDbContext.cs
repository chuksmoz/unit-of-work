using Hahn.ApplicatonProcess.February2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Asset> Assets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
