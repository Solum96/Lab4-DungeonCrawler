using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Trap : GameObject
    {
        public Trap(DungeonMap map, Point location) : base(map, location) { }
        public override char Visual { get; set; } = '-';
        public int TrapDamage { get; private set; }

        public Trap(int trapDamage, DungeonMap map, Point location) : base(map, location)
        {
            TrapDamage = trapDamage;
        }
    }
}