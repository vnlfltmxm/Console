using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Project
{
    enum mDir
    {
        UP,DOWN,LEFT,RIGT
    }


    public class Monster:Unit
    {
        Map map;
        Stopwatch _stopwatch;
        int _s = 1000;

        mDir _dir;
        public bool _b;
       public int _num;
        public int _xKey;
        public int _yKey;

        private int _targetPosX;
        private int _targetPosY;

        public Monster(int posX,int posY,Map map) : base()
        {
            _b = false;
            _stopwatch = new Stopwatch();
            _xKey = posX;
            _yKey = posY;
            this.posY = posY;
            this.posX = posX;
            this.map = map;

            map.map[posY, posX] = eMapState.MONSTER;
            _stopwatch.Start();
        }

        public void RespownM()
        {
            map.map[posY, posX] = eMapState.MONSTER;
        }

        public void Die()
        {
            if (map.map[posY, posX]==eMapState.FIRE)
            {
                _b = true;
            }
        }
      
       

        public bool LeftMoveCheck()
        {
            switch (map.map[posY, posX - 1])
            {
                case eMapState.BOX:
                    return false;
                case eMapState.MONSTER:
                    return false;
                case eMapState.BOOM:
                    return false;
                case eMapState.FIRE:
                    return false;
                case eMapState.WILL:
                    return false;
                default:
                    return true;
            }
        }
        public bool RightMoveCheck()
        {
            switch (map.map[posY, posX + 1])
            {
                case eMapState.BOX:
                    return false;
                case eMapState.MONSTER:
                    return false;
                case eMapState.BOOM:
                    return false;
                case eMapState.FIRE:
                    return false;
                case eMapState.WILL:
                    return false;
                default:
                    return true;
            }
        }
        public bool UPMoveCheck()
        {
            switch (map.map[posY - 1, posX])
            {
                case eMapState.BOX:
                    return false;
                case eMapState.MONSTER:
                    return false;
                case eMapState.BOOM:
                    return false;
                case eMapState.FIRE:
                    return false;
                case eMapState.WILL:
                    return false;
                default:
                    return true;
            }
        }
        public bool DownMoveCheck()
        {
            switch (map.map[posY + 1, posX])
            {
                case eMapState.BOX:
                    return false;
                case eMapState.MONSTER:
                    return false;
                case eMapState.BOOM:
                    return false;
                case eMapState.FIRE:
                    return false;
                case eMapState.WILL:
                    return false;
                default:
                    return true; 
            }
        }
        public void RightMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posX++;
        }
        public void LeftMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posX--;
        }
        public void UPMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY--;
        }
        public void DownMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY++;
        }

        public void ChoceDir()
        {
            Random random = new Random();

            switch (random.Next(0,4))
            {
                case 0:
                    _dir = mDir.UP;
                    break;
                case 1:
                    _dir = mDir.LEFT;
                    break;
                case 2:
                    _dir = mDir.DOWN;
                    break;
                case 3:
                    _dir = mDir.RIGT;
                    break;

            }
        }

        public void MoveCheck()
        {
            LeftMoveCheck();
            RightMoveCheck();
            UPMoveCheck();
            DownMoveCheck();
        }

        public void Move()
        {
            if (_stopwatch.ElapsedMilliseconds >= _s)
            {
                ChoceDir();

                switch (_dir)
                {
                    case mDir.UP:
                        if (UPMoveCheck() == true)
                        {
                            UPMove();
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                            map.map[posY, posX] = eMapState.MONSTER;
                        }
                        else
                        {
                            Move();
                        }
                        break;
                    case mDir.DOWN:
                        if (DownMoveCheck() == true)
                        {
                            DownMove();
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                            map.map[posY, posX] = eMapState.MONSTER;
                        }
                        else
                        {
                            Move();
                        }
                        break;
                    case mDir.LEFT:
                        if (LeftMoveCheck() == true)
                        {
                            LeftMove();
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                            map.map[posY, posX] = eMapState.MONSTER;
                        }
                        else
                        {
                            Move();
                        }
                        break;
                    case mDir.RIGT:
                        if (RightMoveCheck() == true)
                        {
                            RightMove();
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                            map.map[posY, posX] = eMapState.MONSTER;
                        }
                        else
                        {
                            Move();
                        }
                        break;
                }

                _stopwatch.Restart();
            
            }
            else
            {
                return;
            }

            
        }

    }
}
