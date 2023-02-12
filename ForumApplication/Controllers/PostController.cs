using ForumApplication.Models.Repositories;
using ForumApplication.Models;
using Microsoft.AspNetCore.Mvc;
using ForumApplication.ViewModels;

namespace ForumApplication.Controllers
{
    public class PostController : Controller
    {
        public IRepository<Post> Repository { get; }
        public IRepository<Utilisateur> UtilisateurRepository { get; }
        public IRepository<Theme> ThemeRepository { get; }

        public PostController(IRepository<Post> repository, IRepository<Theme> themeRepository, IRepository<Utilisateur> utilisateurRepository)
        {
            Repository = repository;
            UtilisateurRepository = utilisateurRepository;
            ThemeRepository = themeRepository;
        }
        public IActionResult Index()
        {
            var posts = Repository.Lister();
            return View(posts);
        }
        public IActionResult Details(int id)
        {
            var post = Repository.ListerSelonId(id);
            return View(post);
        }

        public IActionResult Create()
        {
            PostTheme viewModel = new PostTheme()
            {
                themes = ThemeRepository.Lister(),
                utilisateurs = UtilisateurRepository.Lister()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(PostTheme viewModel)
        {
            try
            {
                var post = new Post()
                {
                    message = viewModel.message,
                    //datecreationmessage = viewModel.datecreationmessage,
                    sujet = viewModel.sujet,
                    motscle = viewModel.motscle,
                    theme = new Theme
                    
                    {
                        id = viewModel.themeId,
                        titre = ThemeRepository.ListerSelonId(viewModel.themeId).titre
                    },
                    utilisateur = new Utilisateur
                    {
                        id = viewModel.themeId,
                        pseudonyme = UtilisateurRepository.ListerSelonId(viewModel.themeId).pseudonyme
                    }
                };
                Repository.Ajouter(post);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var post = Repository.ListerSelonId(id);
            PostTheme viewModel = new PostTheme
            {
                PostId = post.id,
                message = post.message,
                //datecreationmessage = post.datecreationmessage,
                sujet = post.sujet,
                motscle = post.motscle,
                themeId = post.theme.id,
                utilisateurId = post.utilisateur.id,
                themes = ThemeRepository.Lister(),
                utilisateurs = UtilisateurRepository.Lister()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, PostTheme viewModel)
        {
            try
            {
                var editedPost = new Post
                {
                    id = viewModel.PostId,
                    message = viewModel.message,
                    //datecreationmessage = post.datecreationmessage,
                    sujet = viewModel.sujet,
                    motscle = viewModel.motscle,
                    theme = new Theme
                    {
                        id = viewModel.themeId,
                        titre = ThemeRepository.ListerSelonId(viewModel.themeId).titre
                    }
                };
                Repository.Modifier(id, editedPost);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var post = Repository.ListerSelonId(id);
            return View(post);
        }
        [HttpPost]
        public IActionResult Delete(int id, Post post)
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
