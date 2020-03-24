using Microsoft.Xna.Framework;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; } = "player";
        public bool HasSword { get; set; }

        public bool HasKey { get; set; }    

        public Player(Cell cell) : base(cell)
        {
        }

        public void MovePlayer(MoveDirection move)
        {
            switch ((int)move)
            {
                case 0:
                    Move(1, 0);
                    break;

                case 1:
                    Move(-1, 0);
                    break;

                case 2:
                    Move(0, -1);
                    break;

                case 3:
                    Move(0, 1);
                    break;
                    
            }
        }
    }
}