using Microsoft.AspNetCore.Mvc;
using SousMalins.Models;
using SousMalins.Services;

namespace SousMalins.Controllers
{
    public class TypeCompteController : Controller
    {
        private readonly TypeCompteService _typeCompteService;

        public TypeCompteController(TypeCompteService typeCompteService)
        {
            _typeCompteService = typeCompteService;
        }
        
        public async Task<IActionResult> IndexTypeCompte()
        {
            List<TypeCompte> typeCompteList = await _typeCompteService.GetAllTypesCompteAsync();
            return View(typeCompteList);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateTypeCompte()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeCompte(TypeCompte typeCompte)
        {
            if(!ModelState.IsValid)
            {
                return View(typeCompte);
            }

            try
            {
                await _typeCompteService.CreateTypeCompteAsync(typeCompte);
                TempData["Success"] = "Type de compte crée avec succès";
                return RedirectToAction("IndexTypeCompte");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la création";
                ViewBag.Categories = await _typeCompteService.GetAllTypesCompteAsync();
                return View(typeCompte);
            }
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
