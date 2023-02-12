namespace ForumApplication.Models
{
    public class Post
    {
        private static int nextId = 1;
        public int id { get; set; }
        public string message { get; set; }
        public DateTime datecreationmessage { get; set; }
        public bool sujet { get; set; }
        public string motscle { get; set; }
        public Theme theme { get; set; }
        public Utilisateur utilisateur { get; set; }

        public Post()
        {
            id = nextId++;
        }
    }
}
