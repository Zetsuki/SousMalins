using Microsoft.AspNetCore.Mvc;
using SousMalins.Models;
using SousMalins.Services;

namespace SousMalins.Controllers
{
    public class CategorieController : Controller
    {
        public readonly CategorieService _categorieService;

        public CategorieController (CategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        public async Task<IActionResult> IndexCategorie()
        {
            try
            {
                List<Categorie> list = await _categorieService.GetAllCategoriesAsync();
                return View(list);
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur lors de la récupération des catégories.";
                return View();
            }
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateCategorie()
        {
            ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
                return View(categorie);
            }

            try
            {
                await _categorieService.CreateCategorieAsync(categorie);
                TempData["Success"] = "Catégorie créée avec succès";
                return RedirectToAction("IndexCategorie");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la création";
                ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
                return View(categorie);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> UpdateCategorie(int id)
        {
            ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
            Categorie? categorie = await _categorieService.GetCategorieByIdAsync(id);
            if(categorie != null)
            {
                return View(categorie);
            }
            else
            {
                TempData["Error"] = "Erreur modification catégorie";
                return View("IndexCategorie");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
                return View(categorie);
            }

            try
            {
                await _categorieService.UpdateCategorieAsync(categorie.Id, categorie);
                TempData["Success"] = "Catégorie modifiée avec succès";
                return RedirectToAction("IndexCategorie");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la modification";
                ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
                return View(categorie);
            }
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            Categorie? toDelete = await _categorieService.GetCategorieByIdAsync(id);
            if (toDelete == null)
            {
                TempData["Error"] = "Catégorie introuvable.";
                return RedirectToAction("IndexCategorie");
            }

            return View(toDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategorieConfirmation(int id)
        {
            try
            {
                await _categorieService.DeleteCategorieAsync(id);
                TempData["Success"] = "Catégorie supprimée";
            }
            catch (Exception)
            {
                TempData["Error"] = "Erreur lors de la suppression.";
            }
            return RedirectToAction("IndexCategorie");
        }
        #endregion
    }
}
