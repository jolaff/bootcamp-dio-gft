using gameflix.Interfaces;

namespace gameflix.Models;

public class GameRepository : IRepository<Game>
{
    private List<Game> _games;

    public GameRepository() => _games = new List<Game>();

    public Game GetById(int id) => _games[id];

    public void Insert(Game item) => _games.Add(item);

    public List<Game> Items() => _games;

    public int NextId() => _games.Count;

    public void Remove(int id) => _games[id].Exclude();

    public void UndoRemove(int id) => _games[id].UndoExclude();

    public void Update(int id, Game item) => _games[id] = item;
}