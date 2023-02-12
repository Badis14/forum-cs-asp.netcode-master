namespace ForumApplication.Models.Repositories
{
    public class ForumRepository : IRepository<Forum>
    {
        public IList<Forum> forums { get; set; }
        public ForumRepository()
        {
            forums = new List<Forum>()
            {
                new Forum
                {
                    id= 1,titre="Sport", datecreation=new DateOnly(2022,05,09)
                },
                 new Forum
                {
                    id= 2,titre="Politique",datecreation=new DateOnly(2022,05,09)
                },
                  new Forum
                {
                    id= 3,titre="Developpement informatique",datecreation=new DateOnly(2022,05,09)
                }
            };
        }
        public void Ajouter(Forum element)
        {
            element.id = forums.Max(b => b.id) + 1;
            forums.Add(element);
        }

        public IList<Forum> Lister()
        {
            return forums;
        }

        public Forum ListerSelonId(int id)
        {
            return forums.Single(a => a.id == id);
        }

        public void Modifier(int id, Forum element)
        {
            var ancienneFamille = ListerSelonId(id);
            ancienneFamille.titre = element.titre;
            ancienneFamille.datecreation = element.datecreation;
        }

        public void Supprimer(int id)
        {
            var forum = ListerSelonId(id);
            forums.Remove(forum);
        }
    }
}
