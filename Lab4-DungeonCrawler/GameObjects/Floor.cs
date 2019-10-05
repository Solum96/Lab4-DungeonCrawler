using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Floor : GameObject
    {
        public Floor(DungeonMap map, Point location) : base(map, location) { }

        public override char Visual { get; set; } = '-';
    }
}