namespace rpg_abstraction_oop_project.src.Entities
{
    public class Melee : Hero
    {
        public Melee(string name, int level, string heroType) : base(name, level, heroType)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = heroType;
        }

        public override string Attack() => IsKnight() ? $"{Name} atacou com uma espada de duas mãos!" : $"{Name} furtivamente deu uma punhalada em seu inimigo!";
        public string Attack(int power) => power < 6 ? $"{Name} não causou muito dano no seu ataque" : $"{Name} fez o inimigo sangrar!";

        private bool IsKnight() => HeroType == "Knight" ? true : false;
    }
}