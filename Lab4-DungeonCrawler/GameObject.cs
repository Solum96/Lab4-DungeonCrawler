using System;

namespace Lab4_DungeonCrawler
{
        public abstract class GameObject
        {
            // Object randomizer for traps
            static char[] ObjectRandomizer = new char[] { 'b', '-' };
            static Random randomObject = new Random();
            static int randomIndex = randomObject.Next(ObjectRandomizer.Length);

            // VG? public static string[] DifferentColors = new string[] { "Grey", "Red", "Black" };

            // VG? public string Color { get; set; } = DifferentColors[0];
            public char Floor { get; set; } = '-';
            public char Key { get; set; } = 'k';
            public char Door { get; set; } = 'D';
            // VG? public char Bomb { get; set; } = 'b';
            // VG? public char Trap { get; set; } = ObjectRandomizer[randomIndex];
            // VG? public char Torch = 't';
            public char Exit = 'v';

        }
}
