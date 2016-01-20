using System;

namespace Maze_Game
{
    class MaximumAmountOfMovesException : Exception
    {
        public MaximumAmountOfMovesException()
        {
            
        }
        public MaximumAmountOfMovesException(string message) : base(message)
        {

        }
    }
}
