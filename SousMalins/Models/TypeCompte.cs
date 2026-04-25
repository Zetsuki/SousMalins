using System.ComponentModel.DataAnnotations;

namespace SousMalins.Models
{
    public class TypeCompte
    {
        public int Id { get; set;  }
        [Required]
        public required string Libelle { get; set; }
        public int Plafond { get; set; }

        // Proprietés de navigation
        public List<Compte> Comptes { get; set; } = new();
    }
}
