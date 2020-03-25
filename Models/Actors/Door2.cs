using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Door2 : Actor
    {
        public Door2(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "door2";
    }
}