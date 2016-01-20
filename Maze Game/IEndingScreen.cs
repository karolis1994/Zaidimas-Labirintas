using System.Windows.Forms;

namespace Maze_Game
{
    public interface IEndingScreen
    {
        void EndScreen(Label l, Label l2, string stateMessage, string infoMessage);
    }
}
