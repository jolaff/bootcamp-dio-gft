using gameflix.Interfaces;

namespace gameflix.Models;

public class GameRepository : IRepository<Game>
{
    private List<Game> _games;

    public GameRepository()
    {
        _games = new List<Game>();
    }

    public Game GetById(int id) => _games[id];

    public void Insert(Game item)
    {
        throw new NotImplementedException();
    }

    public List<Game> Items() => _games;

    public int NextId()
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Game item)
    {
        throw new NotImplementedException();
    }
}