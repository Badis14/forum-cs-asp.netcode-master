using ForumApplication.Models.Repositories;
using ForumApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApplication.Controllers
{
    public class ForumController : Controller
    {
        public IRepository<Forum> Repository { get; }

        public ForumController(IRepository<Forum> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            var forums = Repository.Lister();
            return View(forums);
        }
        public IActionResult Details(int id)
        {
            var forum = Repository.ListerSelonId(id);
            return View(forum);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Forum forum)
        {
            try
            {
                Repository.Ajouter(forum);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var forum = Repository.ListerSelonId(id);
            return View(forum);
        }
        [HttpPost]
        public IActionResult Edit(int id, Forum forum)
        {
            try
            {
                Repository.Modifier(id, forum);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var forum = Repository.ListerSelonId(id);
            return View(forum);
        }
        [HttpPost]
        public IActionResult Delete(int id, Forum forum)
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
