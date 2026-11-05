using BoardGamesManagment.Entities;
using Microsoft.EntityFrameworkCore;
using BoardGamesManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesManagment;
    public class AppDbContext : DbContext
    {
        
        
        public DbSet<Games> Games {  get; set; }
        public DbSet<Members> Members   { get; set; }
        public DbSet<Sessions> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BoardGamesDateBase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>().ToTable(g => g.HasCheckConstraint("CK_Games_MinPlayers_BiggerThanZero", "MinPlayers > 0"));
            modelBuilder.Entity<Games>().ToTable(g => g.HasCheckConstraint("CK_Games_MinPlayers_BiggerThanZero", "MaxPlayers > 0"));

            modelBuilder.Entity<Games>().HasMany(g => g.sessions).WithOne(s => s.games).HasForeignKey(s => s.GameId);
            modelBuilder.Entity<Members>().HasMany(m => m.sessions).WithOne(s => s.members).HasForeignKey(s => s.MemberId);
            

        }
    }
