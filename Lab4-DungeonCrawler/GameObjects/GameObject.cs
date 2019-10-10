using System;
using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public abstract class GameObject
    {
        public GameObject(DungeonMap map, Point location)
        {
            Location = location;
            Map = map;
        }

        public virtual char Visual { get; set; }
        public Point Location { get; set; } = new Point();
        public DungeonMap Map { get; set; }

    }
}
