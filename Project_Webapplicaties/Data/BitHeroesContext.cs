using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data
{
    public class BitHeroesContext: DbContext
    {
        public BitHeroesContext(DbContextOptions<BitHeroesContext> options): base(options)
        {

        }

        public DbSet<Gear> Gears { get; set; }
        public DbSet<Geartype> Geartypes { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<BaseStatTotal> BaseStatTotals { get; set; }
        public DbSet<Bonus> Bonussen { get; set; }
        public DbSet<Gear_Bonus> Gear_Bonussen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gear>().ToTable("Gear");
            modelBuilder.Entity<Gear>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Geartype>().ToTable("Geartype");
            modelBuilder.Entity<Geartype>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Rank>().ToTable("Rank");
            modelBuilder.Entity<Rank>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Element>().ToTable("Element");
            modelBuilder.Entity<Element>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Element>().Property(p => p.WeakTo).IsRequired();
            modelBuilder.Entity<Element>().Property(p => p.StrongTo).IsRequired();
            modelBuilder.Entity<BaseStatTotal>().ToTable("BaseStatTotal");
            modelBuilder.Entity<BaseStatTotal>().Property(p => p.Base).IsRequired();
            modelBuilder.Entity<BaseStatTotal>().Property(p => p.Upgrade1).IsRequired();
            modelBuilder.Entity<Bonus>().ToTable("Bonus");
            modelBuilder.Entity<Bonus>().Property(p => p.Explanation).IsRequired();
            modelBuilder.Entity<Gear_Bonus>().ToTable("Gear_Bonus");
        }
    }
}
