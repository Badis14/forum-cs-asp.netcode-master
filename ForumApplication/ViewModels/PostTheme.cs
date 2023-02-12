using ForumApplication.Models;

namespace ForumApplication.ViewModels
{
    public class PostTheme
    {
        public int PostId { get; set; }
        public string message { get; set; }
        public string datecreationmessage { get; set; }
        public bool sujet { get; set; }
        public string motscle { get; set; }
        public int themeId { get; set; }
        public int utilisateurId { get; set; }
        public IList<Theme> themes { get; set; }
        public IList<Utilisateur> utilisateurs { get; set; }
    }
}
