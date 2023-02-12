namespace ForumApplication.Models.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        public IList<Post> posts { get; set; }

        public PostRepository()
        {
            posts = new List<Post>()
            {
                new Post
                {
                    id= 1,
                    message="Bonjour test post",
                    datecreationmessage=new DateTime(2022,05,09),
                    sujet=true,
                    motscle="mot cle pst 1",
                    theme=new Theme{id= 1,titre="Tunis",forum=new Forum{id= 2,titre="Politique"}},
                    utilisateur=new Utilisateur{
                        id=1,
                        pseudonyme="badis",
                        motdepasse="badis2021",
                        email="b.elouni@pi.tn",
                        inscrit=true,
                        valide=true,
                        cheminavatar="/home/badis/avatar.png",
                        signature="HelloWorld",
                        actif=true,
                        admin=true,}
                },
            };
        }
        public void Ajouter(Post element)
        {
            element.id = posts.Max(b => b.id) + 1;
            posts.Add(element);
        }

        public IList<Post> Lister()
        {
            return posts;
        }

        public Post ListerSelonId(int id)
        {
            return posts.Single(a => a.id == id);
        }

        public void Modifier(int id, Post element)
        {
            var anciennePost = ListerSelonId(id);
            anciennePost.message = element.message;
            anciennePost.datecreationmessage = element.datecreationmessage;
            anciennePost.sujet = element.sujet;
            anciennePost.motscle = element.motscle;
            anciennePost.theme = element.theme;
            anciennePost.utilisateur = element.utilisateur;

        }

        public void Supprimer(int id)
        {
            var post = ListerSelonId(id);
            posts.Remove(post);
        }
    }
}
