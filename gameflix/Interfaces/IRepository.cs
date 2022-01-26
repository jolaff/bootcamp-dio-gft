namespace gameflix.Interfaces;

public interface IRepository<T>
{
    List<T> Items();
    T GetById(int id);
    void Insert(T item);
    void Remove(int id);
    void Update(int id, T item);
    int NextId();
}