using System.ComponentModel.DataAnnotations;

namespace SousMalins.Models
{
    public class Compte
    {
        public int Id { get; set;  }
        [Required]
        public required string Libelle { get; set; }
        public int Plafond { get; set; }
        public int SoldeInitial { get; set; }
        public DateTime SoldeInitialDate { get; set; }
        public bool Actif { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string Banque { get; set; }
        [Required]
        public required string Titulaire { get; set; }

        // Proprietés de navigation
        public List<Transaction> Transactions { get; set; } = new();
        public List<Transfert> TransfertsSource { get; set; } = new List<Transfert>();
        public List<Transfert> TransfertsDestination { get; set; } = new List<Transfert>();
    }
}
