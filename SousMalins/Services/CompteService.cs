using Microsoft.EntityFrameworkCore;
using SousMalins.Controllers;
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

        #endregion

        #region Read
        public async Task<List<Compte>> GetAllCompteAsync()
        {
            return await _context.Comptes.ToListAsync();
        }

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
