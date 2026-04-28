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
                TempData["Success"] = "Type de compte crée avec succès.";
                return RedirectToAction("IndexTypeCompte");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la création.";
                ViewBag.Categories = await _typeCompteService.GetAllTypesCompteAsync();
                return View(typeCompte);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> UpdateTypeCompte(int id)
        {
            TypeCompte? typeCompte = await _typeCompteService.GetTypeCompteByIdAsync(id);
            if(typeCompte != null)
            {
                return View(typeCompte);
            }
            else
            {
                TempData["Error"] = "Erreur modification type de compte.";
                return View("IndexTypeCompte");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTypeCompte(TypeCompte typeCompte)
        {
            if (!ModelState.IsValid)
            {
                return View(typeCompte);
            }

            try
            {
                await _typeCompteService.UpdateTypeCompteAsync(typeCompte.Id, typeCompte);
                TempData["Success"] = "Type de compte modifié avec succès.";
                return RedirectToAction("IndexTypeCompte");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la modification.";
                ViewBag.Categories = await _typeCompteService.GetAllTypesCompteAsync();
                return View(typeCompte);
            }
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> DeleteTypeCompte(int id)
        {
            TypeCompte? toDelete = await _typeCompteService.GetTypeCompteByIdAsync(id);
            if (toDelete == null)
            {
                TempData["Error"] = "Type de compte introuvable.";
                return RedirectToAction("IndexTypeCompte");
            }

            return View(toDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTypeCompteConfirmation(int id)
        {
            try
            {
                await _typeCompteService.DeleteTypeCompteAsync(id);
                TempData["Success"] = "Type de compte supprimé.";
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur lors de la suppression.";
            }
            return RedirectToAction("IndexTypeCompte");
        }
        #endregion
    }
}
