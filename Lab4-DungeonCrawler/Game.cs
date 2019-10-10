using System;
using System.Drawing;
using Lab4_DungeonCrawler.Rendering;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public class Game
    {
        public Game()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            Map = new DungeonMap(10, 1, 0, 8, 1, 7, new Size(20, 15));
            Player = new Player(Map, Map.CurrentPlayerLocation);
        }
        private DungeonMap Map { get; set; }
        public static Player Player { get; set; }
        MoveDelta moveDelta = new MoveDelta();

        private IMapRender Renderer { get; set; } = new TextMapRenderer(); // Will be injected through DI in the future!
        
        public void RunGame()
        {
            while (Map.NumberOfLevels <= 3)
            {
                Console.WriteLine("Steps: " + Player.StepCounter);

                if (Player.HasKey) { Console.WriteLine("You have a key."); }
                else { Console.WriteLine("You don't have a key."); }
                if (Player.HasMultiKey) { Console.WriteLine($"You have a multikey with {Player.PlayerMultiKey.UsesLeft} uses."); }
                else { Console.WriteLine("You don't have a multikey."); }

                Renderer.RenderMap(Map);

                char move = Console.ReadKey().KeyChar;
                switch (move)
                {
                    case 'w':
                        moveDelta = new MoveDelta() { DeltaY = -1, DeltaX = 0 };
                        break;

                    case 'a':
                        moveDelta = new MoveDelta() { DeltaY = 0, DeltaX = -1 };
                        break;

                    case 's':
                        moveDelta =  new MoveDelta() { DeltaY = 1, DeltaX = 0 };
                        break;

                    case 'd':
                        moveDelta = new MoveDelta() { DeltaY = 0, DeltaX = 1 };
                        break;

                    default:
                        break;
                }
                Console.Clear();

                Point futureLocation = new Point(Player.Location.X + moveDelta.DeltaY, Player.Location.Y + moveDelta.DeltaX);

                if ((Map.IsDoor(futureLocation) && Player.HasKey) || (Map.IsDoor(futureLocation) && Player.HasMultiKey && Player.PlayerMultiKey.UsesLeft > 0))
                {
                    Player.StepCounter++;
                    Player.HasKey = false;
                    Player.PlayerMultiKey.UsesLeft--;
                    if (Player.PlayerMultiKey.UsesLeft == 0) { Player.HasMultiKey = false; }
                    Map.GenerateMap(Map.MapSize);
                    // return "Used key on door.\r\nEntering new room.";
                }

                if (Map.IsDoor(futureLocation) && !Player.HasKey)
                {
                    //return "You don't have a key.";
                }

                if (Map.IsMonster(futureLocation))
                {
                    var damage = (Map.GetGameObjectAt(futureLocation) as Monster).Damage;
                    Player.StepCounter += damage;
                    Map.MovePlayerInMap(Player.Location, futureLocation);

                    Player.Location = futureLocation;
                    //return $"Battle ensues! You lost (as always), and got punished with {damage} steps.";
                }

                if (Map.IsTrap(futureLocation))
                {
                    var trapDamage = (Map.GetGameObjectAt(futureLocation) as Trap).TrapDamage;
                    Player.StepCounter += trapDamage;
                    Map.MovePlayerInMap(Player.Location, futureLocation);

                    Player.Location = futureLocation;
                    //return $"Your foot gets impaled by a spike. Ouch. You'r punished with {trapDamage} steps.";
                }

                if (Map.IsPrize(futureLocation))
                {
                    var value = (Map.GetGameObjectAt(futureLocation) as Prize).Value;
                    Player.StepCounter -= value;
                    Player.StepCounter = Player.StepCounter < 0 ? 0 : Player.StepCounter;
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.Location = futureLocation;
                    //return $"Battle ensues! You lost (as always), and got punished with {value} steps.";
                }

                if (Map.IsWall(futureLocation))
                {
                    //return "Stop banging your head against the wall. It's not helping anyone.";
                }

                if (Map.IsKey(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.HasKey = true;
                    Player.StepCounter++;
                    Player.Location = futureLocation;
                    //return "You found a key! Well done!";
                }
                if (Map.IsMultiKey(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.HasMultiKey = true;
                    Player.PlayerMultiKey = new MultiKey(Map, Player.Location);
                    Player.StepCounter++;
                    Player.Location = futureLocation;
                    //return "You found a multikey! Well done!";
                }
                if (Map.IsFloor(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.Location = futureLocation;
                    Player.StepCounter++;
                    //return "";
                }
            }
            // End screen
            Console.WriteLine("Congratulations, you won!");
            Console.WriteLine($"You made it in {Player.StepCounter} steps!\nWell done!");
            Console.ReadKey(true);
        }
    }
}
