using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Maze_Game.Properties;

namespace Maze_Game
{
    public partial class GameForm : Form
    {
        private int _tileX;
        private int _tileY;
        private int _movesLeft;
        private readonly Map _m;
        private readonly Player _p;
        private readonly List<Box> _boxes;
        private readonly Lazy<Rock> _r;
        private delegate bool IsLazyInitialized(bool c);
        private readonly TimeCounter _timeCounter;
        private readonly IsLazyInitialized _ili;

        public GameForm(int tileY, int tileX)
        {
            int maxMoved;
            _tileY = tileY;
            _tileX = tileX;
            InitializeComponent();
            _p = new Player();
            _m = new Map();
            var pNf = new PlayerNameForm();
            pNf.ShowDialog();
            try
            {
                _p.Name = pNf.PlayerName;
            }           
            catch (NoNameEnteredException)
            {
                Console.WriteLine("No name has been typed by the player");
                _p.Name = "No name";
            }
            
            nameLbl.Text = _p.Name;
            _boxes = new List<Box>();
            _r = new Lazy<Rock>();          
            string difficulty = pNf.Difficulty;
            IsLazyInitialized anon = delegate(bool c)
            {
                Console.WriteLine("Anonymous method");
                return c;
            };
            anon(_r.IsValueCreated);
            IsLazyInitialized lambda = c => c;
            Console.WriteLine(lambda(_r.IsValueCreated));
            Console.WriteLine(difficulty);
            switch (difficulty)
            {
                case "Easy":
                    _timeCounter = new TimeCounter(40);
                    _boxes.Add(new Box(4, 2));
                    _boxes.Add(new Box(5, 9));
                    maxMoved = 40;
                    break;
                case "Medium":
                    _timeCounter = new TimeCounter(25);
                    _boxes.Add(new Box(4, 2));
                    _boxes.Add(new Box(5, 9));
                    _boxes.Add(new Box(7, 3));                   
                    maxMoved = 35;
                    break;
                case "Hard":
                    _timeCounter = new TimeCounter(15);
                    _r.Value.SetTile(8, 2);
                    _boxes.Add(new Box(4, 2));
                    _boxes.Add(new Box(5, 9));
                    _boxes.Add(new Box(7, 3));
                    _boxes.Add(new Box(3, 10));
                    foreach (var b in _boxes)
                    {
                        b.ChangeBoxPicture();
                    }
                    maxMoved = 26;
                    break;
                default:
                    timeLeftLbl.Visible = false;
                    maxMoved = 26;
                    break;
            }
            _ili = (CheckIfLazyInitialized);
            Console.WriteLine(_ili(_r.IsValueCreated));
            _movesLeft = maxMoved;
            ClientSize = new Size(_m.Lines[0].Length * 32, _m.Lines.Length * 32);
            nameLbl.Location = new Point(75, _m.Lines.Length * 32 - 16);
            showNameLbl.Location = new Point(12, _m.Lines.Length * 32 - 16);
            movesLeftLbl.Location = new Point(_m.Lines[0].Length * 32 - 120, _m.Lines.Length * 32 - 16);
            timeLeftLbl.Location = new Point(_m.Lines[0].Length * 32 - 200, _m.Lines.Length * 32 - 16);
            movesLeftLbl.Text = "You have " + _movesLeft + " moves left.";
            if(_timeCounter != null)
            {
                timeLeftLbl.Text = "Time left: " + _timeCounter.Time;
                _timeCounter.Tick += GameForm_TimeTick;
            }
        }

        public bool CheckIfLazyInitialized(bool c)
        {
            return c;
        }

        IEndingScreen _eS;
        private void End(IEndingScreen endingScreen, Label l, Label l2, string message, string message1)
        {
            _eS = endingScreen;
            _eS.EndScreen(l, l2, message, message1);
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                _m.TooManyMoves(_movesLeft);
            }
            catch(MaximumAmountOfMovesException)
            {
                KeyPress -= GameForm_KeyPress;
                var ls = new LoseScreen();
                End(ls, newLabel, resultlbl, Resources.GameForm_Game_Paint_You_lose_, String.Format("The total amount of moves you made: {0}", _p.Moved));
                if(_timeCounter != null)
                    _timeCounter.Cont = false;
            }     
            if (_m.Lines[_p.TileY][_p.TileX] == 'e')
            {
                KeyPress -= GameForm_KeyPress;
                var vs = new VictoryScreen();
                End(vs, newLabel, resultlbl, Resources.GameForm_Game_Paint_Victory_, String.Format("The total amount of moves you made: {0}", _p.Moved));
                if (_timeCounter != null)
                    _timeCounter.Cont = false;
            }           
            foreach (string line in _m.Lines)
            {
                foreach (char a in line)
                {
                    if (a == 'g')
                    {
                        e.Graphics.DrawImage(_m.Grass, _tileX * 32, _tileY * 32);
                        _tileX++;
                    }
                    else if (a == 'w')
                    {
                        e.Graphics.DrawImage(_m.Wall, _tileX * 32, _tileY * 32);
                        _tileX++;
                    }
                    else if (a == 'e')
                    {
                        e.Graphics.DrawImage(_m.Exit, _tileX * 32, _tileY * 32);
                        _tileX++;
                    }
                }
                _tileX = 0;
                _tileY++;
            }
            _tileY = 0;
            e.Graphics.DrawImage(_p.PlayerIcon, _p.TileX * 32, _p.TileY * 32);
            foreach (Box b in _boxes)
            {
                e.Graphics.DrawImage(b.BoxImage, b.TileX * 32, b.TileY * 32);
            }
            if (_r.IsValueCreated)
                e.Graphics.DrawImage(_r.Value.RockImage, _r.Value.TileX * 32, _r.Value.TileY * 32);           
            movesLeftLbl.Text = "You have " + _movesLeft + " moves left.";
            if(_timeCounter != null)
                timeLeftLbl.Text = "Time left: " + _timeCounter.Time;
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_movesLeft == 0)
            {
                KeyPress -= GameForm_KeyPress;
                Refresh();
            }
            int i = 0;
            bool col = false;
            switch (e.KeyChar)
            {
                case 'w':
                    if (_m.Lines[_p.TileY - 1][_p.TileX] == 'g' || _m.Lines[_p.TileY - 1][_p.TileX] == 'e')
                    {
                        foreach (var b in _boxes)
                        {      
                            if (_p.CollisionUp(b.TileX, b.TileY))
                            {
                                col = true;
                                break;
                            }
                            i++;
                        }
                        if(col)
                        {
                            if (_m.Lines[_p.TileY - 2][_p.TileX] == 'g')
                            {
                                _boxes[i].Move(0, -1);
                                _p.Move(0, -1);
                                _movesLeft--;
                            }
                        }
                        else
                        {
                            _p.Move(0, -1);
                            _movesLeft--;
                        }
                        Refresh();
                    }
                    break;
                case 's':
                    if (_m.Lines[_p.TileY + 1][_p.TileX] == 'g' || _m.Lines[_p.TileY + 1][_p.TileX] == 'e')
                    {
                        foreach (var b in _boxes)
                        {
                            if (_p.CollisionDown(b.TileX, b.TileY))
                            {
                                col = true;
                                break;
                            }
                            i++;
                        }
                        if (col)
                        {
                            if (_m.Lines[_p.TileY + 2][_p.TileX] == 'g')
                            {
                                _boxes[i].Move(0, 1);
                                _p.Move(0, 1);
                                _movesLeft--;
                            }
                        }
                        else
                        {
                            _p.Move(0, 1);
                            _movesLeft--;
                        }
                        Refresh();
                    }
                    break;
                case 'a':
                    if (_m.Lines[_p.TileY][_p.TileX - 1] == 'g' || _m.Lines[_p.TileY][_p.TileX - 1] == 'e')
                    {
                        foreach (var b in _boxes)
                        {
                            if (_p.CollisionLeft(b.TileX, b.TileY))
                            {
                                col = true;
                                break;
                            }
                            i++;
                        }
                        if (col)
                        {
                            if (_m.Lines[_p.TileY][_p.TileX - 2] == 'g')
                            {
                                _boxes[i].Move(-1, 0);
                                _p.Move(-1, 0);
                                _movesLeft--;
                            }
                        }
                        else
                        {
                            _p.Move(-1, 0);
                            _movesLeft--;
                        }
                        Refresh();
                    }
                    break;
                case 'd':
                    if (_m.Lines[_p.TileY][_p.TileX + 1] == 'g' || _m.Lines[_p.TileY][_p.TileX + 1] == 'e')
                    {
                        foreach (var b in _boxes)
                        {
                            if (_p.CollisionRight(b.TileX, b.TileY))
                            {
                                col = true;
                                break;
                            }
                            i++;
                        }
                        if (col)
                        {
                            if (_m.Lines[_p.TileY][_p.TileX + 2] == 'g' && _ili(!_r.IsValueCreated))
                            {
                                _boxes[i].Move(1, 0);
                                _p.Move(1, 0);
                            }
                            else if (_ili(_r.IsValueCreated) && (_p.TileY != _r.Value.TileY || _p.TileX + 2 != _r.Value.TileX) && _m.Lines[_p.TileY][_p.TileX + 2] == 'g')
                            {
                                _boxes[i].Move(1, 0);
                                _p.Move(1, 0);
                                _movesLeft--;
                            }
                        }
                        else
                        {
                            _p.Move(1, 0);
                            _movesLeft--;
                        }
                        Refresh();
                    }
                    break;
            }
        }

        private void GameForm_TimeTick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Refresh()));
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_timeCounter != null)
                _timeCounter.Cont = false;
        }
    }
}
