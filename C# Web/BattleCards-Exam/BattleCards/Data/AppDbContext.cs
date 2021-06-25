using BattleCards.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
       public DbSet<UserCard> UserCards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BattleCards;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>().HasKey(x => new { x.UserId, x.CardId });

            modelBuilder.Entity<UserCard>()
                  .HasOne(uc => uc.User)
                  .WithMany(u => u.UserCards)
                  .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCard>()
                .HasOne(uc => uc.Card)
                .WithMany(b => b.UserCards)
                .HasForeignKey(x => x.CardId);
        }
    }
}
