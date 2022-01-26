
using gameflix.Models;
using gameflix.Enum;

Console.SetWindowSize(150, 50);

var newGame = new Game(1,
"The 4th Coming",
"MMORPG set in a medieval fantasy where you build your character as you progress and defeat monsters. Beware on goblin bridge! Do you feel worthy, punk?",
"Vircom",
1994,
ERating.Everyone);
newGame.AddGenre(EGenre.MassivelyMultiplayer, EGenre.RPG);

Console.WriteLine(newGame);
Console.ReadKey();