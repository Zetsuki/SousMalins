using Microsoft.EntityFrameworkCore;
using SousMalins.Data;
using SousMalins.Models;

namespace SousMalins.Services
{
    public class TypeCompteService
    {
        private readonly SousMalinsDbContext _context;

        public TypeCompteService(SousMalinsDbContext context)
        {
            _context = context;
        }

        #region Create
        public async Task CreateTypeCompteAsync(TypeCompte typeCompte)
        {
            _context.TypeComptes.Add(typeCompte);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public async Task<List<TypeCompte>> GetAllTypesCompteAsync()
        {
            return await _context.TypeComptes.ToListAsync();
        }

        public async Task<TypeCompte?> GetTypeCompteByIdAsync(int id)
        {
            return await _context.TypeComptes.FindAsync(id);
        }

        #endregion

        #region Update
        public async Task UpdateTypeCompteAsync(int id, TypeCompte typeCompte)
        {
            TypeCompte? toUpdate = await _context.TypeComptes.FindAsync(id);
            if (toUpdate != null)
            {
                toUpdate.Libelle = typeCompte.Libelle;
                toUpdate.Plafond = typeCompte.Plafond;

                _context.TypeComptes.Update(toUpdate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Type de compte introuvable");
            }
        }
        #endregion

        #region Delete
        public async Task DeleteTypeCompteAsync(int id)
        {
            TypeCompte? typeCompte = await _context.TypeComptes.FindAsync(id);
            if (typeCompte != null)
            {
                _context.TypeComptes.Remove(typeCompte);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Type de compte introuvable");
            }
        }

        #endregion
    }
}
