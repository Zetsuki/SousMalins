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

        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task CreateCategorieAsync(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
        }
    }
}
