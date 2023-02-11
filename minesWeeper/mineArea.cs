using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesWeeper
{
    class mineArea
    {
        private int x;
        private int y;
        private int mineCount;
        public int X
        {
            get { return x; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    x = value;
                }

            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    y = value;
                }

            }
        }

        public int MineCount
        {
            get { return mineCount; }
            set
            {
                if(value<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    mineCount = value;
                }
            }
        }

        public mineArea(int x, int y, int mineCount)
        {
            this.X = x;
            this.Y = y;
            this.MineCount = mineCount;
        }

        public void xy()
        {
            Console.WriteLine("X: " + X + "\nY: " + Y+"\nMineCount: "+MineCount);
        }


    }
}

