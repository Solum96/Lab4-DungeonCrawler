using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Monster : GameObject , IDamageDealer
    {
        public override char Visual { get; set; } = 'M';
        public int Damage { get; private set; } = 10;

        public Monster(int damage, DungeonMap map, Point location) : base(map, location)
        {
            Damage = damage;
        }

        public void DoDamage()
        {
            Game.Player.StepCounter += Damage;
        }
    }
}