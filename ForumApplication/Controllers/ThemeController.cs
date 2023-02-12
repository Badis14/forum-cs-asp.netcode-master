using ForumApplication.Models.Repositories;
using ForumApplication.Models;
using Microsoft.AspNetCore.Mvc;
using ForumApplication.ViewModels;

namespace ForumApplication.Controllers
{
    public class ThemeController : Controller
    {
        public IRepository<Theme> Repository { get; }
        public IRepository<Forum> ForumRepository { get; }

        public ThemeController(IRepository<Theme> repository, IRepository<Forum> forumrepository)
        {
            Repository = repository;
            ForumRepository = forumrepository;
        }
        public IActionResult Index()
        {
            var themes = Repository.Lister();
            return View(themes);
        }
        public IActionResult Details(int id)
        {
            var theme = Repository.ListerSelonId(id);
            return View(theme);
        }

        public IActionResult Create()
        {
            ThemeForum viewModel = new ThemeForum()
            {
                forums = ForumRepository.Lister()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ThemeForum viewModel)
        {
            try
            {
                var theme = new Theme()
                {
                    titre = viewModel.titre,
                    forum = new Forum
                    {
                        id = viewModel.forumId,
                        titre = ForumRepository.ListerSelonId(viewModel.forumId).titre
                    }
                };
                Repository.Ajouter(theme);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var theme = Repository.ListerSelonId(id);
            ThemeForum viewModel = new ThemeForum
            {
                ThemeId = theme.id,
                titre = theme.titre,
                forumId = theme.forum.id,
                forums = ForumRepository.Lister()
             };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, ThemeForum viewModel)
        {
            try
            {
                var editedTheme = new Theme
                {
                    id = viewModel.ThemeId,
                    titre = viewModel.titre,
                    forum = new Forum
                    {
                        id = viewModel.forumId,
                        titre = ForumRepository.ListerSelonId(viewModel.forumId).titre
                    }
                };
                Repository.Modifier(id, editedTheme);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var theme = Repository.ListerSelonId(id);
            return View(theme);
        }
        [HttpPost]
        public IActionResult Delete(int id, Theme theme)
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
