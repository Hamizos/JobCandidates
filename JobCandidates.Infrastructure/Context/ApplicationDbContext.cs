using JobCandidates.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidates.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Candidate> candidates { get; set; }
    }
}
