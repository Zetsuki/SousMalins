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

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
