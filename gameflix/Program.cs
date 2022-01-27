using gameflix.Models;
using gameflix.Enum;

Console.SetWindowSize(180, 60);
var _repository = new GameRepository();

#region PLACEHOLDER GAMES FOR TESTING PURPOSE - TO BE DELETED
var gamesList = _repository.Items();

var t4c = new Game(1, "The 4th Coming", "Some random description. In web pages developers usually use Lorem Ipsum bla bla bla. But I decided not to. Do you feel worthy punk?", "Vircom", 1995, ERating.AdultsOnly);
var wow = new Game(2, "World of Warcraft", "Most played MMORPG EVER! I used to play a Healer Shaman! I am a man who walks alone totalmente para voce ir achar qualquer coisa e to sem palavras", "Blizzard", 2010, ERating.Everyone);
var mu = new Game(3, "MU Online", "Chinese game, did play some but quit quit.", "Random Chinese", 2008, ERating.Teen);
var uo = new Game(4, "Ultima Online", "Best sandbox MMORPF ever!", "Forgot", 1990, ERating.RatingPending);

t4c.AddGenre(EGenre.RPG, EGenre.MassivelyMultiplayer);

gamesList.Add(t4c);
gamesList.Add(wow);
gamesList.Add(mu);
gamesList.Add(uo);
#endregion

//GamesList();
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

                break;
            case "4":

                break;
            case "5":

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
    if (gamesList.Count > 0)
    {
        foreach (var game in gamesList)
        {
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

 1 - View Details | 2 - Add New | 3 - Update Info | 4 - Remove | 5 - List Removed | 6 - Undo Remove | B - Back to Main Menu | X - Exit");
    Console.WriteLine();
    Console.Write(" Please choose an option: ");
}

void ShowDetails()
{
    Console.SetCursorPosition(5, 8);
    Console.Write("Enter game Id to show details: ");
    int gameId = (int.Parse(Console.ReadLine()) - 1);

    var game = _repository.GetById(gameId);

    Console.SetCursorPosition(5, 10);
    Console.WriteLine(game.Details());
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("     Press ENTER to go back to Games List...");
}

void AddGame()
{
    Console.SetCursorPosition(5, 8);
    Console.WriteLine("Add new game to the list");
    Console.WriteLine();

    foreach (int genre in Enum.GetValues(typeof(EGenre)))
    {
        Console.WriteLine($"{"",8}{genre,2} - {Enum.GetName(typeof(EGenre), genre)}");
    }

}