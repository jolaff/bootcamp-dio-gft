using gameflix.Models;
using gameflix.Enum;

GetUserInput();

void GetUserInput()
{
    string userInput = Menu();
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

        userInput = Menu();
    }
}

string Menu()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("Gameflix - Gamefy your flix!");
    Console.WriteLine();
    Console.WriteLine("How can I help you?");
    Console.WriteLine();
    Console.WriteLine("1 - List your games");
    Console.WriteLine("2 - View game details");
    Console.WriteLine("3 - Add new game");
    Console.WriteLine("4 - Update game info");
    Console.WriteLine("5 - Remove game");
    Console.WriteLine("X - Exit");
    Console.WriteLine();
    Console.Write("Please choose an option: ");

    string userInput = Console.ReadLine().ToUpper();

    return userInput;
}