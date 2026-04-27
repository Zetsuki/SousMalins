using Microsoft.EntityFrameworkCore;
using SousMalins.Models;

namespace SousMalins.Data
{
    public class SousMalinsDbContext : DbContext
    {
        public DbSet<Compte> Comptes => Set<Compte>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Categorie> Categories => Set<Categorie>();
        public DbSet<TypeCompte> TypeComptes => Set<TypeCompte>();

        public SousMalinsDbContext(DbContextOptions<SousMalinsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Compte)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CompteId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Categorie)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategorieId);

            modelBuilder.Entity<Compte>()
                .HasOne(c => c.TypeCompte)
                .WithMany(tc => tc.Comptes)
                .HasForeignKey(c => c.TypeCompteId);

            modelBuilder.Entity<Categorie>()
                .HasOne(c => c.CategorieMere)
                .WithMany(c => c.SousCategories)
                .HasForeignKey(c => c.CategorieMereId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}