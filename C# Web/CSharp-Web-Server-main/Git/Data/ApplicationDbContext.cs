namespace Git.Data
{
    using Git.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext()
        //{
        //}

        //public ApplicationDbContext(DbContextOptions dbContextOptions)
        //    : base(dbContextOptions)
        //{
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Commit> Commits { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Git;Integrated Security=true;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        ////    modelBuilder.Entity<Commit>(x => x.HasOne(c => c.Creator)
        ////    .WithMany(cr => cr.Commits)
        ////    .HasForeignKey(k=>k.CreatorId)
        ////    .OnDelete(DeleteBehavior.NoAction));

        ////    modelBuilder.Entity<Commit>(x => x.HasOne(c => c.Repository)
        ////.WithMany(cr => cr.Commits)
        ////.HasForeignKey(k => k.RepositoryId)
        ////.OnDelete(DeleteBehavior.NoAction));
        //}
    }
}