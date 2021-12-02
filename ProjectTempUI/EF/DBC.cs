using Microsoft.EntityFrameworkCore;
using MidtermProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.EF
{
    public class DBC : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<HeroType> HeroTypes { get; set; }
        public DbSet<EnemyType> enemyTypes { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Hero_Name> Hero_Names { get; set; }
        public DbSet<Encounter_Intro_Text> Intro_Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if (!ob.IsConfigured)
            {

                ob.UseSqlServer("Server=localhost\\SQLEXPRESS;" +
                    "Database=PathetiQuest;" +
                    "Trusted_Connection=True;" +
                    "MultipleActiveResultSets=true;");

            }

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Hero>()
           .HasMany(left => left.EquippedItem)
           .WithMany(right => right.Owning_Hero)
           .UsingEntity(join => join.ToTable("Hero <-> Item"));

            mb.Entity<Ability>()
            .HasMany(left => left.unit_with_ability)
            .WithMany(right => right.Abilities)
            .UsingEntity(join => join.ToTable("Ability <-> Unit"));

            mb.Entity<Hero_Name>()
            .HasMany(left => left.Players)
            .WithMany(right => right.Names_Used)
            .UsingEntity(join => join.ToTable("HeroName <-> Player"));

            mb.Entity<Player>()
            .HasMany(left => left.InventoryItem)
            .WithMany(right => right.Owning_Player)
            .UsingEntity(join => join.ToTable("Player <-> Inventory Item"));

        }


    }
}
