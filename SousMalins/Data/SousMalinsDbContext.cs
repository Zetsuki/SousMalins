using Microsoft.EntityFrameworkCore;
using SousMalins.Models;

namespace SousMalins.Data
{
    public class SousMalinsDbContext : DbContext
    {
        public DbSet<Compte> Comptes => Set<Compte>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Categorie> Categories => Set<Categorie>();
        public DbSet<Transfert> Transferts => Set<Transfert>();

        public SousMalinsDbContext(DbContextOptions<SousMalinsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cardinalités et comportements on delete
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Compte)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CompteId)
                .OnDelete(DeleteBehavior.Cascade); // archivage, sinon delete !!!

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Categorie)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategorieId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(tction => tction.Transfert)
                .WithMany(tfert => tfert.Transactions)
                .HasForeignKey(t => t.TransfertId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transfert>()
                .HasOne(t => t.CompteSource)
                .WithMany(c => c.TransfertsSource)
                .HasForeignKey(t => t.CompteSourceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transfert>()
                .HasOne(t => t.CompteDestination)
                .WithMany(c => c.TransfertsDestination)
                .HasForeignKey(t => t.CompteDestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Contraintes
            modelBuilder.Entity<Compte>()
                .HasIndex(c => c.Libelle)
                .IsUnique();

            modelBuilder.Entity<Categorie>()
                .HasIndex(c => c.Libelle)
                .IsUnique();
        }
    }
}