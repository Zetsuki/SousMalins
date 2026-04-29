namespace SousMalins.Models
{
    public class Compte
    {
        public int Id { get; set;  }
        public int TypeCompteId { get; set; }

        // Proprietés de navigation
        public TypeCompte TypeCompte { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = new();
        public List<SnapshotCompte> SnapshotsCompte { get; set; } = new();
        public List<Transfert> Transferts { get; set; } = new();
    }
}
