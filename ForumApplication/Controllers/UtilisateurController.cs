using ForumApplication.Models.Repositories;
using ForumApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApplication.Controllers
{
    public class UtilisateurController : Controller
    {
        public IRepository<Utilisateur> Repository { get; }

        public UtilisateurController(IRepository<Utilisateur> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            var utilisateurs = Repository.Lister();
            return View(utilisateurs);
        }
        public IActionResult Details(int id)
        {
            var utilisateur = Repository.ListerSelonId(id);
            return View(utilisateur);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Utilisateur utilisateur)
        {
            try
            {
                Repository.Ajouter(utilisateur);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var utilisateur = Repository.ListerSelonId(id);
            return View(utilisateur);
        }
        [HttpPost]
        public IActionResult Edit(int id,Utilisateur utilisateur)
        {
            try
            {
                Repository.Modifier(id,utilisateur);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var utilisateur = Repository.ListerSelonId(id);
            return View(utilisateur);
        }
        [HttpPost]
        public IActionResult Delete(int id, Utilisateur utilisateur)
        {
            try
            {
                Repository.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
