namespace Lab4_DungeonCrawler
{
    internal class Monster
    {
        public int Damage { get; private set; }
        public char Name { get; private set; }

        public Monster(int damage, char name)
        {
            this.Damage = damage;
            this.Name = name;
        }

        public int DoDamage()
        {
            return Damage;
        }
    }
}