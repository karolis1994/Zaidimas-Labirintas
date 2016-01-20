using System;

namespace Maze_Game
{
    public class NoNameEnteredException : Exception
    {
        public NoNameEnteredException()
        {
            
        }

        public NoNameEnteredException(String message) : base(message)
        {
            
        }
    }
}
