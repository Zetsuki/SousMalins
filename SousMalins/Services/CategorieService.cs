using Microsoft.EntityFrameworkCore;
using SousMalins.Data;
using SousMalins.Models;

namespace SousMalins.Services
{
    public class CategorieService
    {
        public readonly AppDbContext _context;

        public CategorieService(AppDbContext context)
        {
            _context = context;
        }

        #region Create
        public async Task CreateCategorieAsync(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task<Categorie?> GetCategorieByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        #endregion

        #region Update
        public async Task UpdateCategorieAsync(int id, Categorie categorie)
        {
            Categorie? toUpdate = await _context.Categories.FindAsync(id);
            if(toUpdate != null)
            {
                toUpdate.Libelle = categorie.Libelle;
                toUpdate.CategorieMereId = categorie.CategorieMereId;

                _context.Categories.Update(toUpdate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Catégorie introuvable");
            }
        }

        #endregion

        #region Read
        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteCategorieAsync(int id)
        {
            Categorie? categorie = await _context.Categories.FindAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Catégorie introuvable");
            }
        }
        #endregion
    }
}
