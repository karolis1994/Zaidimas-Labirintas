using System;
using System.Threading;

namespace Maze_Game
{
    public delegate void MyEventHandler(object source, EventArgs e);
    class TimeCounter
    {
        public event MyEventHandler Tick;
        private readonly Thread _thr;
        public bool Cont;
        public TimeCounter(int t)
        {
            Cont = true;
            Time = t;
            _thr = new Thread(TimePassed);
            _thr.Start();
        }
        public void TimePassed()
        {
            while (Time > 0 && Cont)
            {
                Time--;
                Console.WriteLine(Time);
                Thread.Sleep(1000);
                if (Tick != null)
                {
                    Tick(this, new EventArgs());
                }
            }   
            _thr.Abort();
        }

        public int Time { get; private set; }
    }
}
