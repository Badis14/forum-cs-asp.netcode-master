namespace ForumApplication.Models
{
    public class Theme
    {
        private static int nextId = 1;
        public int id { get; set; }
        public string titre { get; set; }
        public Forum forum { get; set; }

        public Theme()
        {
            id = nextId++;
        }
    }
}
