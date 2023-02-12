namespace ForumApplication.ViewModels;
using ForumApplication.Models;

public class ThemeForum
{
    public int ThemeId { get; set; }
    public string titre { get; set; }
    public int forumId { get; set; }
    public IList<Forum> forums { get; set; }
}
