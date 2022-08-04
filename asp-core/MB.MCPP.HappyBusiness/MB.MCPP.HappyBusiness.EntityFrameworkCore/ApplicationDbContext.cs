using MB.MCPP.HappyBusiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.HappyBusiness.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
    }
}
