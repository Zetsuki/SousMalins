using Microsoft.AspNetCore.Mvc;
using SousMalins.Data;
using SousMalins.Models;
using SousMalins.Services;
using SousMalins.ViewModels.Compte;
using static SousMalins.ViewModels.Compte.IndexCompteViewModel;

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
            var comptes = await _compteService.GetAllCompteAsync();

            var vm = new IndexCompteViewModel
            {
                Comptes = new List<IndexCompteItem>()
            };

            foreach (var c in comptes)
            {
                vm.Comptes.Add(new IndexCompteItem
                {
                    Id = c.Id,
                    Libelle = c.Libelle,
                    Type = c.Type,

                    // TODO implementation methode pour calculer
                    SoldeActuel = 2,
                    VariationMensuelle = 2
                });
            }

            return View(vm);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateCompte()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompte(Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return View(compte);
            }

            try
            {
                await _compteService.CreateCompteAsync(compte);
                TempData["Success"] = "Compte créée avec succès";
                return RedirectToAction("IndexCompte");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la création";
                return View(compte);
            }
        }

        #endregion

        #region Read

        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> UpdateCompte(int id)
        {
            Compte? compte = await _compteService.GetCompteByIdAsync(id);
            if (compte != null)
            {
                return View(compte);
            }
            else
            {
                TempData["Error"] = "Erreur modification compte.";
                return View("IndexCompte");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompte(Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return View(compte);
            }

            try
            {
                await _compteService.UpdateCompteAsync(compte.Id, compte);
                TempData["Success"] = "Compte modifié avec succès.";
                return RedirectToAction("IndexCompte");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la modification.";
                return View(compte);
            }
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            Compte? toDelete = await _compteService.GetCompteByIdAsync(id);
            if (toDelete == null)
            {
                TempData["Error"] = "Compte introuvable.";
                return RedirectToAction("IndexCompte");
            }

            return View(toDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompteConfirmation(int id)
        {
            try
            {
                await _compteService.DeleteCompteAsync(id);
                TempData["Success"] = "Compte supprimé.";
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur lors de la suppression.";
            }
            return RedirectToAction("IndexCompte");
        }
        #endregion
    }
}
