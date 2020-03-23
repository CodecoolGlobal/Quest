using System;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Cell : IDrawable
    {
        public Actor Actor { get; set; }
        public CellType CellType { get; set; }

        public int X { get; }
        public int Y { get; }

        public string TileName => CellType.ToString("g").ToLowerInvariant();

        private readonly GameMap _gameMap;

        public Cell(GameMap gameMap, int x, int y, CellType cellType)
        {
            _gameMap = gameMap;
            X = x;
            Y = y;
            CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy)
        {
            return _gameMap.GetCell(X + dx, Y + dy) ?? this;
        }


        public bool IsCellFree()
        {
            var emptyCell = this.Actor == null && this.CellType == CellType.Floor;
            var collectableSword = this.Actor != null && this.Actor.TileName == "sword";

            return emptyCell || collectableSword;
        }

        public string WhoIsInCell()
        {
            return this.Actor != null ? this.Actor.TileName : "NO ONE";
        }

        public void DecreaseActorsLifeAndKillHimIfNecessary(string actorName)
        {
            if (WhoIsInCell() != actorName) return;
            this.Actor.Health -= 1;
            if (this.Actor.Health < 0)
            {
                this.Actor = null;
            }
        }


    }
}