namespace SousMalins.Models
{
    public class Transfert
    {
        public int Id { get; set; }
        public int Montant { get; set; }
        public DateTime Date { get; set; }
        public string? Libelle { get; set; }
        public int CompteSourceId { get; set; }
        public int CompteDestinationId { get; set; }
        public bool Actif { get; set; }

        // Proprietés de navigation
        public required Compte CompteSource { get; set; }
        public required Compte CompteDestination { get; set; } 
        public List<Transaction> Transactions { get; set; } = new();
    }
}
