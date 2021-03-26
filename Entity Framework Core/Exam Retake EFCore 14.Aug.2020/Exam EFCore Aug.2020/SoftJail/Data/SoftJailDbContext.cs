namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Prisoner>(entity =>
            {
                entity
            .HasOne(p => p.Cell)
            .WithMany(c => c.Prisoners)
            .HasForeignKey(p => p.CellId);
            });

            builder.Entity<Officer>(entity =>
            {
                entity.HasOne(o => o.Department)
                .WithMany(d => d.Officers)
                .HasForeignKey(o => o.DepartmentId);

            });

            builder.Entity<Mail>(entity =>
            {
                entity.HasOne(m => m.Prisoner)
                .WithMany(p => p.Mails)
                .HasForeignKey(m => m.PrisonerId);
            });

            builder.Entity<OfficerPrisoner>(entity =>
            {
                entity.HasKey(x => new { x.PrisonerId, x.OfficerId});

                entity.HasOne(of => of.Officer)
                .WithMany(p => p.OfficerPrisoners)
                .HasForeignKey(of => of.OfficerId);

                entity.HasOne(of => of.Prisoner)
                .WithMany(o => o.PrisonerOfficers)
                .HasForeignKey(of => of.PrisonerId);
            });
                 

        }
    }
}