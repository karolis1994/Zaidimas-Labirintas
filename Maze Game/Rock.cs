using System.Drawing;

namespace Maze_Game
{
    public class Rock : Objects
    {
        private readonly Bitmap _rock = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Rock.png");

        public Rock()
        {
            TileX = 0;
            TileY = 0;
        }
        public Bitmap RockImage
        {
            get { return _rock; }
        }
    }
}
