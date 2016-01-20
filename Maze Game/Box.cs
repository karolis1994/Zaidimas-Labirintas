using System.Drawing;
using System.Runtime.Versioning;

namespace Maze_Game
{
    public class Box : Objects
    {
        private Bitmap _box = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Box.png");

        public Box(int x, int y)
        {
            TileX = x;
            TileY = y;
        }
        public Bitmap BoxImage
        {
            get { return _box; }
            set { _box = value; }
        }
    }

}
