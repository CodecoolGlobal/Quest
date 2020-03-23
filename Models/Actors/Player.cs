namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; } = "player";
        public bool HasSword { get; set; }

        public Player(Cell cell) : base(cell)
        {
        }

        public void MovePlayer(string where)
        {
            switch (where.ToLower())
            {
                case "right":
                    Move(1, 0);
                    break;

                case "left":
                    Move(-1, 0);
                    break;

                case "up":
                    Move(0, -1);
                    break;

                case "down":
                    Move(0, 1);
                    break;
                    
            }
        }
    }
}