using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Key : Actor
    {
        public Key(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "key";
    }

}