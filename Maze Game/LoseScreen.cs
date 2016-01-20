using System.Drawing;
using System.Windows.Forms;

namespace Maze_Game
{
    class LoseScreen : IEndingScreen
    {
        public void EndScreen(Label l, Label l2, string stateMessage, string infoMessage)
        {
            l.Text = stateMessage;
            l.Visible = true;
            l2.Text = infoMessage;
            l2.Location = new Point(0, 120);
            l2.Visible = true;
        }
    }
}
