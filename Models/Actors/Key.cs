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
    public class Key2 : Actor
    {
        public Key2(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "key2";
    }

    public class Door : Actor
    {
        public Door(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "door";
    }

    public class Gun : Actor
    {
        public Gun(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "gun";
    }

    public class Headmask : Actor
    {
        public Headmask(Cell cell) : base(cell) 
        {
        }

        public override string TileName { get; } = "headmask";
    }
}