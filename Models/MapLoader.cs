using Codecool.Quest.Models.Actors;
using System.IO;

namespace Codecool.Quest.Models
{
    public class MapLoader
    {
        public static GameMap LoadMap()
        {
            using var stream = new StreamReader("map.txt");
            var firstLine = stream.ReadLine();
            var firstLineSplit = firstLine.Split(' ');

            var width = int.Parse(firstLineSplit[0]);
            var height = int.Parse(firstLineSplit[1]);

            var map = new GameMap(width, height, CellType.Empty);

            for (var y = 0; y < height; y++)
            {
                var line = stream.ReadLine();

                for (var x = 0; x < width; x++)
                {
                    if (x < line.Length)
                    {
                        var cell = map.GetCell(x, y);

                        switch (line[x])
                        {
                            case ' ':

                                cell.CellType = CellType.Empty;
                                break;

                            case '#':

                                cell.CellType = CellType.Wall;
                                break;

                            case '.':

                                cell.CellType = CellType.Floor;
                                break;

                            case 's':

                                cell.CellType = CellType.Floor;
                                map.Skeleton = new Skeleton(cell);
                                break;

                            case '@':

                                cell.CellType = CellType.Floor;
                                map.Player = new Player(cell);
                                break;


                            case 'm':

                                cell.CellType = CellType.Floor;
                                map.Monster = new Monster(cell);
                                break;

                            case 't':
                                cell.CellType = CellType.Floor;
                                map.Sword = new Sword(cell);
                                break;

                            case 'k':
                                cell.CellType = CellType.Floor;
                                map.Key = new Key(cell);
                                break;


                            case 'd':
                                cell.CellType = CellType.Floor;
                                map.Door = new Door(cell);
                                break;

                            case 'i':
                                cell.CellType = CellType.Floor;
                                map.Key2 = new Key2(cell);
                                break;

                            case 'g':
                                cell.CellType = CellType.Floor;
                                map.Gun = new Gun(cell);
                                break;

                            case 'h':
                                cell.CellType = CellType.Floor;
                                map.Headmask = new Headmask(cell);
                                break;

                            case 'b':
                                cell.CellType = CellType.Floor;
                                map.Door2 = new Door2(cell);
                                break;

                            case 'c' :
                                cell.CellType = CellType.Floor;
                                map.Crown = new Crown(cell);
                                break;

                        }
                    }
                }
            }

            return map;
        }
    }
}