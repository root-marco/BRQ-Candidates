using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Certification>().ToTable("Certification");

            modelBuilder.Entity<Skill>()
                .HasOne(x => x.Candidate)
                .WithMany(x => x.Skills)
                .HasForeignKey("SkillId");

            modelBuilder.Entity<Certification>()
                .HasOne(x => x.Candidate)
                .WithMany(x => x.Certifications)
                .HasForeignKey("CertificationId");
        }
    }
}
