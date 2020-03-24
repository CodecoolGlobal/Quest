namespace Codecool.Quest.Models.Actors
{
    public class Monster : Actor
    {
        public Monster(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "monster";

    }
}