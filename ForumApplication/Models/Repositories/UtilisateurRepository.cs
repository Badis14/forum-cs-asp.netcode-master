using System.Security.Cryptography.Xml;

namespace ForumApplication.Models.Repositories
{
    public class UtilisateurRepository : IRepository<Utilisateur>
    {

        private IList<Utilisateur> utilisateurs;
        public UtilisateurRepository()
        {
            utilisateurs = new List<Utilisateur>() {
                new Utilisateur
                {
                    id=1,
                    pseudonyme="badis",
                    motdepasse="badis2022",
                    email="b.elouni@pi.tn",
                    inscrit=true,
                    valide=true,
                    cheminavatar="/home/badis/avatar.png",
                    signature="HelloWorld",
                    actif=true,
                    admin=true,
                },
                new Utilisateur
                {
                    id=2,
                    pseudonyme="iheb",
                    motdepasse="iheb2022",
                    email="s.arwa.mnakbi@pi.tn",
                    inscrit=true,
                    valide=true,
                    cheminavatar="/home/arwa/avatar.png",
                    signature="HelloWorld",
                    actif=true,
                    admin=false,
                },

            };

        }
        public void Ajouter(Utilisateur element)
        {
            element.id = utilisateurs.Max(b => b.id) + 1;
            utilisateurs.Add(element);
        }

        public IList<Utilisateur> Lister()
        {
            return utilisateurs;
        }

        public Utilisateur ListerSelonId(int id)
        {
            return utilisateurs.Single(b => b.id == id);
        }

        public void Modifier(int id, Utilisateur element)
        {
            var ancienUtilisateur = ListerSelonId(id);
            ancienUtilisateur.pseudonyme = element.pseudonyme;
            ancienUtilisateur.motdepasse = element.motdepasse;
            ancienUtilisateur.email = element.email;
            ancienUtilisateur.inscrit = element.inscrit;
            ancienUtilisateur.valide = element.valide;
            ancienUtilisateur.cheminavatar = element.cheminavatar;
            ancienUtilisateur.signature = element.signature;
            ancienUtilisateur.actif = element.actif;
            ancienUtilisateur.admin = element.admin;
        }

        public void Supprimer(int id)
        {
            var utilisateur = ListerSelonId(id);
            utilisateurs.Remove(utilisateur);
        }
    }
}