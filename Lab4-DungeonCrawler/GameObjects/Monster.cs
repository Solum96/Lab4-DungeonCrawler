using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Monster : GameObject
    {
        public override char Visual { get; set; } = 'M';
        public int Damage { get; private set; }

        public Monster(int damage, DungeonMap map, Point location) : base(map, location)
        {
            Damage = damage;
        }
    }
}