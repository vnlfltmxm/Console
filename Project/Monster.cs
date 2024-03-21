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


    public class Monster:Unit,IUnit
    {
        private mDir _dir;

        private Map map;
        private Stopwatch _stopwatch;

        private int _xKey;
        private int _yKey;
        private int _s = 1000;

        public int xKey { get { return _xKey; } }
        public int yKey { get { return _yKey; } }



        public Monster(int posX,int posY,Map map) : base(map,posX,posY)
        {
            _stopwatch = new Stopwatch();
        //    this.posY = posY;
            //this.posX = posX;
            this.map = map;

            _xKey = posX;
            _yKey = posY;

            map.map[posY, posX] = eMapState.MONSTER;
            _stopwatch.Start();
        }


        public void Die()
        {
            if (map.map[posY, posX]==eMapState.FIRE)
            {
                die = true;
            }
        }



        public override bool LeftMoveCheck()
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
        public override bool RightMoveCheck()
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
        public override bool UPMoveCheck()
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
        public override bool DownMoveCheck()
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
        //public void RightMove()
        //{
        //    beforePosX = posX;
        //    beforePosY = posY;
        //    posX++;
        //}
        //public void LeftMove()
        //{
        //    beforePosX = posX;
        //    beforePosY = posY;
        //    posX--;
        //}
        //public void UPMove()
        //{
        //    beforePosX = posX;
        //    beforePosY = posY;
        //    posY--;
        //}
        //public void DownMove()
        //{
        //    beforePosX = posX;
        //    beforePosY = posY;
        //    posY++;
        //}

        public void ChooseDir()
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

        public bool MoveCheck()
        {
            if (LeftMoveCheck() == false && RightMoveCheck() == false && UPMoveCheck() == false && DownMoveCheck() == false)
            {
                return false;
            }
            
            return true;
            
            
        }

        public void MoveAction()
        {
            if (_stopwatch.ElapsedMilliseconds >= _s && MoveCheck() == true) 
            {
                ChooseDir();

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
                            MoveAction();
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
                            MoveAction();
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
                            MoveAction();
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
                            MoveAction();
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
