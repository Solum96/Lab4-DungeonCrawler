using System;
using System.Drawing;
using Lab4_DungeonCrawler.Rendering;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public partial class Game
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

        private IMapRender Renderer { get; set; } = new TextMapRenderer(); // Will be injected through DI in the future.

        public void RunGame()
        {
            while (Map.NumberOfLevels <= 3)
            {
                Console.WriteLine("Steps: " + Player.StepCounter);

                if (Player.HasKey) { Console.WriteLine("You have a key."); }
                else { Console.WriteLine("You don't have a key."); }
                if (Player.HasMultiKey) { Console.WriteLine($"You have a multikey with {Player.MultiKey.UsesLeft} uses."); }
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
                        moveDelta = new MoveDelta() { DeltaY = 1, DeltaX = 0 };
                        break;

                    case 'd':
                        moveDelta = new MoveDelta() { DeltaY = 0, DeltaX = 1 };
                        break;

                    default:
                        break;
                }
                Console.Clear();

                Point futureLocation = new Point(Player.Location.X + moveDelta.DeltaY, Player.Location.Y + moveDelta.DeltaX);

                if ((Map.IsDoor(futureLocation) && Player.HasKey) || (Map.IsDoor(futureLocation) && Player.HasMultiKey && Player.MultiKey.UsesLeft > 0))
                {
                    Player.StepCounter++;
                    Player.HasKey = false;
                    Player.MultiKey.UsesLeft--;
                    if (Player.MultiKey.UsesLeft == 0) { Player.HasMultiKey = false; }
                    Map.GenerateMap(Map.MapSize);
                    // Used key on door. Entering new room.
                }

                if (Map.IsDoor(futureLocation) && !Player.HasKey)
                {
                    // You don't have a key.
                }

                if (Map.IsDamageDealer(futureLocation))
                {
                    (Map.GetGameObjectAt(futureLocation) as IDamageDealer).DoDamage();

                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.Location = futureLocation;
                    // Player took damage from either a monster or a trap depending on object at futureLocation.
                }

                if (Map.IsPrize(futureLocation))
                {
                    var value = (Map.GetGameObjectAt(futureLocation) as Prize).Value;
                    Player.StepCounter -= value;
                    Player.StepCounter = Player.StepCounter < 0 ? 0 : Player.StepCounter;
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.Location = futureLocation;
                    // Player found prize.
                }

                if (Map.IsWall(futureLocation))
                {
                    // Player can't move through walls.
                }

                if (Map.IsKey(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.HasKey = true;
                    Player.StepCounter++;
                    Player.Location = futureLocation;
                    // Player found a key.
                }
                if (Map.IsMultiKey(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.HasMultiKey = true;
                    Player.MultiKey = new MultiKey(Map, Player.Location);
                    Player.StepCounter++;
                    Player.Location = futureLocation;
                    // Player found a multikey.
                }
                if (Map.IsFloor(futureLocation))
                {
                    Map.MovePlayerInMap(Player.Location, futureLocation);
                    Player.Location = futureLocation;
                    Player.StepCounter++;
                    // Moves player.
                }
            }
            // End screen
            Console.WriteLine("Congratulations, you won!");
            Console.WriteLine($"You made it in {Player.StepCounter} steps!\nWell done!");
            Console.ReadKey(true);
        }
    }
}
