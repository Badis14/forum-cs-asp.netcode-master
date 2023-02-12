namespace ForumApplication.Models
{
    public class Forum
    {
        private static int nextId = 1;

        public int id { get; set; }
        public string titre { get; set; }
        public DateOnly datecreation { get; set; }

        public Forum()
        {
            id = nextId++;
        }
    }
}
