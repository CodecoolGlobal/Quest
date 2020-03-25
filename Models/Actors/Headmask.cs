using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Headmask : Actor
    {
        public Headmask(Cell cell) : base(cell) 
        {
        }

        public override string TileName { get; } = "headmask";
    }
}