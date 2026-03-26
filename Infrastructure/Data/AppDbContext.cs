using ExchangeLeadSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeLeadSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadNote> LeadNotes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}