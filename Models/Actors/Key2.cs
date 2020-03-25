using System.Text.Encodings.Web;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Key2 : Actor
    {
        public Key2(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "key2";
    }
}