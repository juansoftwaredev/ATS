using Microsoft.EntityFrameworkCore;
using ATS.Domain.Entities;

namespace ATS.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(e =>
            {
                e.HasKey(i => i.IdCandidate);
            });

            modelBuilder.Entity<CandidateExperience>(entity =>
            {
                entity.HasKey(item => item.IdCandidateExperience);
            });
        }
    }
}
