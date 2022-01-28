using gameflix.Models;
using gameflix.Enum;
using System.Text.RegularExpressions;

Console.SetWindowSize(180, 60);
var _repository = new GameRepository();

GetUserInput();

void GetUserInput()
{
    BuildMainMenu();

    string userInput = Console.ReadLine();
    while (userInput.ToUpper() != "X")
    {
        switch (userInput)
        {
            case "1":
                BuildDetailsMenu();
                break;
            case "2":
                BuildAddMenu();
                break;
            case "3":
                BuildEditMenu();
                break;
            case "4":
                BuildDeleteMenu();
                break;
            case "5":
                BuildUndeleteMenu();
                break;
            default:
                BuildMainMenu();
                break;
        }
        userInput = Console.ReadLine();
    }
}

void BuildMainMenu()
{
    HeadMenu();
    GamesList();
    ActionMenu();
}

void BuildDetailsMenu()
{
    HeadMenu();
    ActionMenu();
    ShowDetails();
}

void BuildAddMenu()
{
    HeadMenu();
    ActionMenu();
    AddGame();
}

void BuildEditMenu()
{
    HeadMenu();
    ActionMenu();
    EditGame();
}

void BuildDeleteMenu()
{
    HeadMenu();
    ActionMenu();
    RemoveGame();
}

void BuildUndeleteMenu()
{
    HeadMenu();
    RemovedList();
    ActionMenu();
    UndoRemoveGame();
}

void HeadMenu()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine(@" Gameflix - Gamefy your flix!

 Here is your favorite games list!
------------------------------");
    Console.WriteLine();
}

void GamesList()
{
    if (_repository.Items().Count > 0)
    {
        foreach (var game in _repository.Items())
        {
            if (!game.IsRemoved())
                Console.WriteLine(game);
        }
    }
    else
    {
        Console.WriteLine(" There is no game registered in the list.");
    }
}

void RemovedList()
{
    if (_repository.Items().Count > 0)
    {
        foreach (var game in _repository.Items())
        {
            if (game.IsRemoved())
                Console.WriteLine(game);
        }
    }
    else
    {
        Console.WriteLine(" There is no game registered in the list.");
    }
}

void ActionMenu()
{
    Console.SetCursorPosition(0, 53);
    Console.WriteLine(@"------------------------------
 How can i help you?

 1 - View Details | 2 - Add New | 3 - Update Info | 4 - Remove | 5 - Undo Remove | B - Back to Main Menu | X - Exit");
    Console.WriteLine();
    Console.Write(" Please choose an option: ");
}

void ShowDetails()
{
    Console.SetCursorPosition(5, 8);
    Console.Write("Enter game Id to show details: ");
    int gameId = (int.Parse(Console.ReadLine()));

    var game = _repository.GetById(gameId);

    Console.SetCursorPosition(5, 10);
    Console.WriteLine(game.Details());
    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

void AddGame()
{
    Console.SetCursorPosition(2, 6);
    Console.WriteLine("Add new game to the list");
    Console.WriteLine();

    ConfirmAndSave(GetGameDetailsFromUser(_repository.NextId()));

    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

void EditGame()
{
    Console.SetCursorPosition(2, 6);
    Console.Write("Enter game id to edit: ");
    int idGame = int.Parse(Console.ReadLine());

    ConfirmAndEdit(GetGameDetailsFromUser(idGame), idGame);

    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

void RemoveGame()
{
    Console.SetCursorPosition(2, 6);
    Console.Write("Enter game id to remove: ");
    int idGame = int.Parse(Console.ReadLine());

    ConfirmAndDelete(idGame);

    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

void UndoRemoveGame()
{
    Console.SetCursorPosition(5, 8);
    Console.Write("Enter game id that you wish to return to the list: ");
    int idGame = int.Parse(Console.ReadLine());

    ConfirmAndUndelete(idGame);

    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

Game GetGameDetailsFromUser(int id)
{
    foreach (int genre in Enum.GetValues(typeof(EGenre)))
        Console.WriteLine($"{"",8}{genre,2} - {Enum.GetName(typeof(EGenre), genre)}");

    Console.WriteLine();
    Console.Write("     Choose the genre, separeted by comma (ex: 1,2,3): ");
    string inputGenreToConvert = Console.ReadLine();

    Console.Write("     What is the game title? ");
    string inputTitle = Console.ReadLine();

    Console.Write("     Please input the description: ");
    string inputDescription = Console.ReadLine();

    Console.Write("     Type in the name of the developer: ");
    string inputDeveloper = Console.ReadLine();

    Console.Write("     Year the game has been released: ");
    int inputYear = int.Parse(Console.ReadLine());

    Console.Write("     Pick a rating ( ");
    foreach (int rating in Enum.GetValues(typeof(ERating)))
        Console.Write($"{rating,2} - {Enum.GetName(typeof(ERating), rating) }");
    Console.Write(" ): ");
    int inputRating = int.Parse(Console.ReadLine());

    Console.Write("     Does the game have an alias? ");
    string inputAlias = Console.ReadLine();

    var game = new Game(id: id,
                        title: inputTitle,
                        genres: ConvertStringToEnumList<EGenre>(inputGenreToConvert),
                        description: inputDescription,
                        developer: inputDeveloper,
                        year: inputYear,
                        rating: (ERating)inputRating,
                        alias: inputAlias);

    Console.SetCursorPosition(5, Console.CursorTop);
    Console.WriteLine(game.Details());

    return game;
}

void ConfirmAndSave(Game gameToBeAdded)
{
    Console.WriteLine();
    Console.Write($"{"",8} Are you sure you want to add {gameToBeAdded.GetAlias()} (Y/N) ? ");
    string confirmation = Console.ReadLine();
    if (confirmation.ToUpper() == "Y")
        _repository.Insert(gameToBeAdded);
}

void ConfirmAndEdit(Game gameToBeAdded, int id)
{
    Console.WriteLine();
    Console.Write($"{"",8} Are you sure you want to edit {gameToBeAdded.GetAlias()} (Y/N) ? ");
    string confirmation = Console.ReadLine();
    if (confirmation.ToUpper() == "Y")
        _repository.Update(id, gameToBeAdded);
}

void ConfirmAndDelete(int id)
{
    Console.WriteLine();
    Console.Write($"{"",8} Are you sure you want to remove this game from your list (Y/N) ? ");
    string confirmation = Console.ReadLine();
    if (confirmation.ToUpper() == "Y")
        _repository.Remove(id);
}

void ConfirmAndUndelete(int id)
{
    Console.WriteLine();
    Console.Write($"{"",8} Are you sure you want to remove this game from your list (Y/N) ? ");
    string confirmation = Console.ReadLine();
    if (confirmation.ToUpper() == "Y")
        _repository.UndoRemove(id);
}

List<T> ConvertStringToEnumList<T>(string userInput) where T : struct, System.Enum
{
    var inputEnum = new List<T>();

    Match rgx = Regex.Match(userInput, @"\d+");
    while (rgx.Success)
    {
        var values = Enum.GetName(typeof(T), int.Parse(rgx.Value));
        inputEnum.Add(Enum.Parse<T>(values));
        rgx = rgx.NextMatch();
    }

    return inputEnum;
}