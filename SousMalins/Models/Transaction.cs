using System.ComponentModel.DataAnnotations;

namespace SousMalins.Models
{
    public class Transaction
    {
        public int Id {  get; set; }
        public int Montant { get; set; }
        public string? Libelle { get; set; }
        public DateTime Date { get; set; }
        public int CategorieId { get; set; }
        public int CompteId { get; set; }

        // Proprietés de navigation
        public Categorie? Categorie { get; set; }
        public Compte Compte { get; set; } = null!;
    }
}
