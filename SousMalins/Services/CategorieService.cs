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

        #region Read
        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteCategorieAsync(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
