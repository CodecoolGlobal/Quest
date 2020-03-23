namespace Codecool.Quest.Models.Actors
{
    public class Sword : Actor
    {
        public Sword(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "sword";
    }
}