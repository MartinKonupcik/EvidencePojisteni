using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EvidencePojisteni
{
    public class EvidenceDbContext: DbContext
    {
        public DbSet<PojistenaOsoba> PojisteneOsoby { get; set; }
        public DbSet<Pojisteni> Pojisteni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=evidence.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PojistenaOsoba>()
                .HasKey(p => p.CisloPojistence);

            modelBuilder.Entity<Pojisteni>()
                .HasOne(p => p.PojistenaOsoba)
                .WithMany(o => o.Pojisteni)
                .HasForeignKey(p => p.CisloPojistence)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
