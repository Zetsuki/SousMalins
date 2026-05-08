namespace SousMalins.ViewModels.Compte
{
    public class IndexCompteViewModel
    {
        public required List<IndexCompteItem> Comptes { get; set; }

        public class IndexCompteItem
        {
            public int Id { get; set; }
            public required string Libelle { get; set; }
            public required string Type { get; set; }

            public decimal SoldeActuel { get; set; }
            public decimal VariationMensuelle { get; set; }
        }
    }
}
