using Microsoft.EntityFrameworkCore;
using SousMalins.Data;
using SousMalins.Models;

namespace SousMalins.Services
{
    public class CompteService
    {
        private readonly SousMalinsDbContext _context;

        public CompteService(SousMalinsDbContext context)
        {
            _context = context;
        }

        #region Create
        public async Task CreateCompteAsync(Compte compte)
        {
            compte.SoldeInitialDate = DateTime.Now;
            compte.Actif = true;
            _context.Comptes.Add(compte);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public async Task<List<Compte>> GetAllCompteAsync()
        {
            return await _context.Comptes.ToListAsync();
        }
        public async Task<Compte?> GetCompteByIdAsync(int id)
        {
            return await _context.Comptes.FindAsync(id);
        }

        #endregion

        #region Update
        public async Task UpdateCompteAsync(int id, Compte compte)
        {
            Compte? toUpdate = await _context.Comptes.FindAsync(id);
            if (toUpdate != null)
            {
                toUpdate.Libelle = compte.Libelle;
                toUpdate.Plafond = compte.Plafond;
                toUpdate.Actif = compte.Actif;
                toUpdate.Type = compte.Type;
                toUpdate.Banque = compte.Banque;
                toUpdate.Titulaire = compte.Titulaire;

                _context.Comptes.Update(toUpdate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Compte introuvable");
            }
        }
        #endregion

        #region Delete
        public async Task DeleteCompteAsync(int id)
        {
            Compte? compte = await _context.Comptes.FindAsync(id);
            if (compte != null)
            {
                _context.Comptes.Remove(compte);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Compteintrouvable");
            }
        }
        #endregion
    }
}
