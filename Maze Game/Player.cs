using System;
using System.Drawing;

namespace Maze_Game
{
    internal class Player : Objects
    {

        private Bitmap playerIcon = new Bitmap(@"c:\users\karolis\documents\visual studio 2013\Projects\Maze Game\Maze Game\Player.png");

        private String _name;

        /**
	     * Main constructor
	     * Loads image, sets the coordinates
	     */

        public Player()
        {
            TileX = 1;
            TileY = 1;
        }

        /**
	     * Method to return the image of player
	     * @return image
	     */

        public Bitmap PlayerIcon
        {
            get { return playerIcon; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /**
	     * Method to check collision to the right side
	     * @param objectTileX
	     * @param objectTileY
	     * @return
	     */
        public bool CollisionRight(int objectTileX, int objectTileY)
        {
            return objectTileX == TileX + 1 && objectTileY == TileY;
        }

        /**
	     * Method to check collision to the left side
	     * @param objectTileX
	     * @param objectTileY
	     * @return
	     */
        public bool CollisionLeft(int objectTileX, int objectTileY)
        {
            return objectTileX == TileX - 1 && objectTileY == TileY;
        }

        /**
	     * Method to check collision to the top side
	     * @param objectTileX
	     * @param objectTileY
	     * @return
	     */
        public bool CollisionUp(int objectTileX, int objectTileY)
        {
            return objectTileX == TileX && objectTileY == TileY - 1;
        }

        /**
	     * Method to check collision to the bottom side
	     * @param objectTileX
	     * @param objectTileY
	     * @return
	     */
        public bool CollisionDown(int objectTileX, int objectTileY)
        {
            return objectTileX == TileX && objectTileY == TileY + 1;
        }

        public override String ToString()
        {
            return string.Format("Player name is: {0} the coordinates are: {1} {2}", _name, TileX, TileY);
        }
    }
}
