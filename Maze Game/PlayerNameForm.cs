using System;
using System.Windows.Forms;

namespace Maze_Game
{
    public partial class PlayerNameForm : Form
    {
        public string PlayerName
        {
            get
            {
                if(nameBox.Text == "")
                    throw new NoNameEnteredException("No name entered");
                return nameBox.Text;                 
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                PlayerName = value;
            }
        }

        public string Difficulty
        {
            get { return listBox1.Text; }
        }

        public PlayerNameForm()
        {
            InitializeComponent();
        }
    }
}
