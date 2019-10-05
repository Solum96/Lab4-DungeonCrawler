namespace Lab4_DungeonCrawler
{
    public class Monster : GameObject
    {
        public int Damage { get; private set; }
        public char Name { get; private set; }

        public Monster(int damage, char name)
        {
            this.Damage = damage;
            this.Name = name;
        }
    }
}