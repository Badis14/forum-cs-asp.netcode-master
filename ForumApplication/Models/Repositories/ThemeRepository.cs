namespace ForumApplication.Models.Repositories
{
    public class ThemeRepository : IRepository<Theme>
    {
        public IList<Theme> themes { get; set; }

        public ThemeRepository()
        {
            themes = new List<Theme>()
            {
                new Theme
                {
                    id= 1,titre="Web",forum=new Forum{id= 3,titre="Developpement informatique" }
                },
                new Theme
                {
                    id= 3,titre="Tunis",forum=new Forum{id= 2,titre="Politique"}
                },

            };
        }
        public void Ajouter(Theme element)
        {
            element.id = themes.Max(b => b.id) + 1;
            themes.Add(element);
        }

        public IList<Theme> Lister()
        {
            return themes;
        }

        public Theme ListerSelonId(int id)
        {
            return themes.Single(a => a.id == id);
        }

        public void Modifier(int id, Theme element)
        {
            var ancienneTheme = ListerSelonId(id);
            ancienneTheme.titre = element.titre;
            ancienneTheme.forum = element.forum;    

        }

        public void Supprimer(int id)
        {   
            var theme = ListerSelonId(id);
            themes.Remove(theme);
        }
    }
}
