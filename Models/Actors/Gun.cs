using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Gun : Actor
    {
        public Gun(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "gun";
    }
}