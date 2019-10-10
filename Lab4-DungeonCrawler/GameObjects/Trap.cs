using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Trap : GameObject , IDamageDealer
    {
        public Trap(int damage, DungeonMap map, Point location) : base(map, location) { }
        public override char Visual { get; set; } = '-';
        public int Damage { get; private set; } = 3;

        public void DoDamage()
        {
            Game.Player.StepCounter += Damage;
        }
    }
}