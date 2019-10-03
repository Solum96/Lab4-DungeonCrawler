using System;

namespace Lab4_DungeonCrawler
{
    partial class Program
    {
        public abstract class GameObject
        {
            public GameObject()
            {

            }

            static char[] ObjectRandomizer = new char[] { 'k', 't', 'b' };
            static Random randomObject = new Random();
            static int randomIndex = randomObject.Next(ObjectRandomizer.Length);

            public char Key { get; set; } = 'k';
            public char Door { get; set; } = 'D';
            public char Bomb { get; set; } = 'b';
            public char Trap { get; set; } = ObjectRandomizer[randomIndex];
            public char Torch = 't';
            public char Exit = 'v';

        }
    }
}
