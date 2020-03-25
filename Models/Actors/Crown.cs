using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Crown : Actor
    {
        public Crown(Cell cell) : base(cell)
        {
            Health = 0;
        }

        public override string TileName { get; } = "crown";
    }
}