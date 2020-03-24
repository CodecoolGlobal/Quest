using Microsoft.Xna.Framework;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; } = "player";
        public bool HasSword { get; set; }

        public bool HasKey { get; set; }

        public bool HasKey2 { get; set; }

        public bool HasGun { get; set; }    


        public bool HasHeadmask { get; set; }


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

        public bool CollectItemOrFight(Cell cell)
        {
            var actorInCell = cell.GetActorInCellIfPresent();
            if (actorInCell == null)
            {
                return false;
            }

            return HandleDifferentActors(actorInCell, cell);
        }

        private bool HandleDifferentActors(Actor actor, Cell cell)
        {
            switch (actor.TileName)
            {
                case "sword":
                    HasSword = true;
                    cell.Actor = null;
                    return true;

                case "key":
                    HasKey = true;
                    cell.Actor = null;
                    return true;

                case "key2":
                    HasKey2 = true;
                    cell.Actor = null;
                    return true;

                case "door":
                    if (HasKey)
                    {
                        cell.Actor = null;
                        return true;
                    }
                    return false;

                case "door2":
                    if (!HasKey2) return false;
                    cell.Actor = null;
                    return true;

                case "gun":
                    HasGun = true;
                    cell.Actor = null;
                    return true;

                case "headmask":
                    HasHeadmask = true;
                    cell.Actor = null;
                    return true;

                default:
                    return false;
            }
            
        }
    }
}