namespace ForumApplication.Models
{
    public class Utilisateur
    {
        private static int nextId = 1;
        public int id { get; set; }
        public string pseudonyme { get; set; }
        public string motdepasse { get; set; }
        public string email { get;set; }
        public bool inscrit { get; set; }
        public bool valide { get; set; }
        public String cheminavatar { get; set;}
        public String signature { get; set;}
        public bool actif { get; set;}   
        public bool admin { get; set; }

        public Utilisateur()
        {
            id = nextId++;
        }
    }
}
