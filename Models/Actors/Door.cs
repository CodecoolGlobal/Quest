using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Door : Actor
    {
        public Door(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "door";
    }
}