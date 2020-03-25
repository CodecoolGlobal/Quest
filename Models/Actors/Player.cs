using System.ComponentModel.Design;
using Microsoft.Xna.Framework;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; } = "player";
        public bool HasSword { get; set; }
        public bool HasCrown { get; set; }  

        public bool HasKey { get; set; }

        public bool HasKey2 { get; set; }

        public bool HasGun { get; set; }    


        public bool HasHeadmask { get; set; }


        public Player(Cell cell) : base(cell)
        {
            Health = 25;
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
            switch (actorInCell)
            {
                case null:
                    return false;
                default:
                    return HandleDifferentActors(actorInCell, cell);
            }
        }

        private bool HandleDifferentActors(Actor actor, Cell cell)
        {
            switch (actor.TileName)
            {

                case "skeleton":
                    return Fight(actor, cell);

                case "monster":
                    return Fight(actor, cell);

                default:
                    return CollectSimpleItem(actor, cell);
            }
            
        }

        private bool Fight(Actor actor, Cell cell)
        {
            var isFree = false;
            if (HasGun && HasSword && HasHeadmask)
            {
                actor.Health -= 4;
                isFree = CheckIfDead(actor, cell);
            }
            else if (HasSword && HasGun)
            {
                Health -= 1;
                actor.Health -= 4;
                isFree = CheckIfDead(actor, cell);
            }

            else if (HasSword)
            {
                Health -= 2;
                actor.Health -= 2;
                isFree  = CheckIfDead(actor, cell);


            }
            else if (HasGun)
            {
                Health -= 2;
                actor.Health -= 2;
                isFree = CheckIfDead(actor, cell);
            }
            else if (!HasHeadmask && !HasSword)
            {
                Health -= 3;
                isFree = false;
            }

            return isFree;
        }

        private bool CollectSimpleItem(IDrawable actor, Cell cell)
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
                    if (!HasKey) return false;
                    cell.Actor = null;
                    return true;

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

                case "crown":
                    HasCrown = true;
                    cell.Actor = null;
                    return true;

                default:
                    return false;
            }

        }

        private static bool CheckIfDead(Actor actor, Cell cell)
        {
            if (actor.Health > 0) return false;
            cell.Actor = null;
            return true;

        }
    }
}