namespace ForumApplication.Models.Repositories
{
    public interface IRepository<T>
    {
        IList<T> Lister(); // getAll() 
        T ListerSelonId(int id); //getById()
        void Ajouter(T element);
        void Modifier(int id, T element);
        void Supprimer(int id);
    }
}
