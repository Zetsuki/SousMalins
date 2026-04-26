using System.ComponentModel.DataAnnotations;

namespace SousMalins.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        [Required]
        public required string Libelle { get; set; }
        public int? CategorieMereId { get; set; }

        // Proprietés de navigation
        public List<Transaction> Transactions { get; set; } = new();
        public Categorie? CategorieMere { get; set; }
        public List<Categorie> SousCategories { get; set; } = new();
    }
}
