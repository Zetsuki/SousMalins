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

        public async Task<IActionResult> Index()
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

        [HttpGet]
        public async Task<IActionResult> CreationCategorie()
        {
            ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreationCategorie(Categorie categorie)
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
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Erreur lors de la création";
                ViewBag.Categories = await _categorieService.GetAllCategoriesAsync();
                return View(categorie);
            }
        }
    }
}
