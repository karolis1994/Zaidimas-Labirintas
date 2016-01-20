using System.Drawing;

namespace Maze_Game
{
    class Map
    {
        public string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\Karolis\Documents\Visual Studio 2013\Projects\Maze Game\Maze Game\Map.txt");
        public Bitmap Grass = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Grass.png");
        public Bitmap Wall = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Wall.png");
        public Bitmap Exit = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Exit.png");

        public bool TooManyMoves(int ml)
        {
            if (ml <= 0)
                throw new MaximumAmountOfMovesException("Too many moves made.");
            return true;
        }
    }
}
