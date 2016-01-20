using System.Drawing;

namespace Maze_Game
{
    static class BoxExtensions
    {
        public static Box ChangeBoxPicture(this Box b)
        {
            b.BoxImage = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Boxv2.png");
            return b;
        }

    }
}
