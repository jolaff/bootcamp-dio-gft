namespace rpg_abstraction_oop_project.src.Entities
{
    public class Wizard : Hero
    {
        public Wizard(string name, int level, string heroType) : base(name, level, heroType)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = heroType;
        }

        public override string Attack() => IsWhiteWizard() ? $"{Name} lançou um feitiço de cura!" : $"{Name} lançou uma bola de fogo!";
        public string Attack(int power) => power < 6 ? $"{Name} lançou um feitiço fraco..." : $"{Name} lançou um feitiço poderoso!";

        private bool IsWhiteWizard() => HeroType == "White Wizard" ? true : false;
    }
}