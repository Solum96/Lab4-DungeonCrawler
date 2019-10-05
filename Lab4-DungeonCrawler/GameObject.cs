using System;

namespace Lab4_DungeonCrawler
{
        public abstract class GameObject
        {
            // Object randomizer for traps
            static char[] ObjectRandomizer = new char[] { 'k', 't', 'b', '-' };
            static Random randomObject = new Random();
            static int randomIndex = randomObject.Next(ObjectRandomizer.Length);

            public static string[] DifferentColors = new string[] { "Grey", "Red", "Black" };

            public string Color { get; set; } = DifferentColors[0];
            public char Floor { get; set; } = '-';
            public char Key { get; set; } = 'k';
            public char Door { get; set; } = 'D';
            public char Bomb { get; set; } = 'b';
            public char Trap { get; set; } = ObjectRandomizer[randomIndex];
            public char Torch = 't';
            public char Exit = 'v';

        }
}
