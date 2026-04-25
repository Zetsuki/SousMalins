using System.ComponentModel.DataAnnotations;

namespace SousMalins.Models
{
    public class Compte
    {
        public int Id { get; set;  }
        public int Montant { get; set; }
        public int TypeCompteId { get; set; }
        public DateTime Date { get; set; }

        // Proprietés de navigation
        public TypeCompte TypeCompte { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = new();
    }
}
