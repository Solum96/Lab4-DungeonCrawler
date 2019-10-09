using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Prize : GameObject
    {
        public Prize(int value, DungeonMap map, Point location) : base(map, location)
        {
            Value = value;
        }
        public override char Visual { get; set; } = 'P';
        public int Value { get; set; }


    }
}