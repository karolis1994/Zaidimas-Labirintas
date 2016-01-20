using System;

namespace Maze_Game
{
    public class Objects
    {
        private int _moved;
        private int _tileX, _tileY;

        /**
	     * Method to change the coordinates of the object
	     * @param x coordinate
	     * @param y coordinate
	     */
        public void SetTile(int x, int y)
        {
            TileX = x;
            TileY = y;
        }

        /**
	     * TileX properties
	     */
        public int TileX
        {
            get { return _tileX; }
            set
            {
                if (value >= 0)
                {
                    _tileX = value;
                }
                else
                {
                    throw new Exception("Negative coordinate input.");
                }
            }
        }

        /**
	     * TileY properties
	     */
        public int TileY
        {
            get { return _tileY; }
            set
            {
                if (value >= 0)
                {
                    _tileY = value;
                }
                else
                {
                    throw new Exception("Negative coordinate input.");
                }
            }
        }

        public int Moved
        {
            get { return _moved; }
        }

        /**
	     * Method to move the object
	     * @param dx how many tiles to move in x axis
	     * @param dy how many tiles to move in y axis
	     */
        public void Move(int dx, int dy)
        {
            TileX += dx;
            TileY += dy;
            _moved += 1;
        }

        /**
	     * Method to print the description of the object.
	     */
        public void PrintDescription()
        {
            Console.WriteLine("This object is on the tile with coordinates: " + TileX + " " + TileY);
        }

    }
}
