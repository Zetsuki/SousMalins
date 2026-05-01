using Microsoft.AspNetCore.Mvc;
using SousMalins.Data;
using SousMalins.Models;
using SousMalins.Services;

namespace SousMalins.Controllers
{
    public class CompteController : Controller
    {
        private readonly CompteService _compteService;

        public CompteController(CompteService compteService)
        {
            _compteService = compteService;
        }

        public async Task<IActionResult> IndexCompte()
        {
            List<Compte> list = await _compteService.GetAllCompteAsync();
            return View(list);
        }

        #region Create

        #endregion

        #region Read

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
