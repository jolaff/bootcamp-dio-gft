namespace rpg_abstraction_oop_project.src.Entities
{
    public class Hero
    {
        public Hero(string name, int level, string heroType)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = heroType;
        }

        public string Name;
        public int Level;
        public string HeroType;

        public override string ToString() => $"O herói {Name} está no nível {Level} e é do tipo {HeroType}.";

        public virtual string Attack() => $"{Name} não conseguiu realizar um ataque bem sucedido!";
    }
}