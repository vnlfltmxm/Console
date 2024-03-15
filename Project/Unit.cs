using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Unit
    {
        private int _moveCount;
        private int _posX;
        private int _posY;
        private int _beforePosX;
        private int _beforePosY;

        public int moveCount { get { return _moveCount; } set { _moveCount = value; } }
        public int posX { get { return _posX; } set { _posX = value; } }
        public int posY { get { return _posY; } set { _posY = value; } }

        public int beforePosX { get { return _beforePosX; }set { _beforePosX = value; } }
        public int beforePosY { get { return _beforePosY; } set { _beforePosY = value; } }

        public Unit(int moveCount) 
        {
            
        }


    }
}
