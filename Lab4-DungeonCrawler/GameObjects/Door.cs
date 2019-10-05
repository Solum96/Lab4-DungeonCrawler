using System;
using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Door : GameObject
    {
        public Door(DungeonMap map, Point location) : base(map, location) { }

        public override char Visual { get; set; } = 'D';
    }
}
