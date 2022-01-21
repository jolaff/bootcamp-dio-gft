using rpg_abstraction_oop_project.src.Entities;

Melee knight = new Melee("Arthur", 99, "Knight");
Wizard whiteWizard = new Wizard("Gandalf", 99, "White Wizard");

Console.WriteLine(knight.Attack());
Console.WriteLine(whiteWizard.Attack());