using gameflix.Models;
using gameflix.Enum;
Console.SetWindowSize(180, 60);

GamesList();


GetUserInput();

void GetUserInput()
{
    Menu();

    string userInput = Console.ReadLine();
    while (userInput.ToUpper() != "X")
    {
        switch (userInput)
        {
            case "1":

                break;
            case "2":

                break;
            case "3":

                break;
            case "4":

                break;
            case "5":

                break;
            default:
                Menu();
                break;
        }
        userInput = Console.ReadLine();
    }
}

void GamesList()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine(@" Gameflix - Gamefy your flix!

 Here is your favorite games list!
------------------------------");
}

void Menu()
{
    Console.SetCursorPosition(0, 53);
    Console.WriteLine(@"------------------------------
 How can i help you?

 1 - View Details | 2 - Add New | 3 - Update Info | 4 - Remove | 5 - List Removed | 6 - Undo Remove | X - Exit");
    Console.WriteLine();
    Console.Write(" Please choose an option: ");
}