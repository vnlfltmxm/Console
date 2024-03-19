using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Player: Unit
    {
        Map map;
        Queue<Boom> _boomQueue;

        private int _fireLength;
        private int _maxBoomCount;
        private int _boomCount;

        public int fireLength { get { return _fireLength; } set { _fireLength = value; } }
        public int maxBoomCount { get { return _maxBoomCount; } set { _maxBoomCount = value; } }
        public int boomCount { get { return _boomCount; } set { _boomCount = value; } }
        public Queue<Boom> boomq { get { return _boomQueue; } set { _boomQueue = value; } }

        public Player(Map map) : base()
        {
            this.map = map;
            _maxBoomCount = 1;
            _boomQueue = new Queue<Boom>();
            posX = 10;
            posY = 10;
            beforePosX = posX;
            beforePosY = posY;
            _fireLength = 2;
            _boomCount = 1;
            
        }

        public bool MoveRightCheck()
        {
            switch (map.map[posY, posX + 1])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        public bool MoveUPCheck()
        {
            switch (map.map[posY - 1, posX])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        public bool MoveLeftCheck()
        {
            switch (map.map[posY, posX - 1])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }
        public bool MoveDownCheck()
        {
            switch (map.map[posY + 1 , posX])
            {
                case eMapState.WILL:
                    return false;
                case eMapState.BOX:
                    return false;
                case eMapState.BOOM:
                    return false;
                default:
                    return true;
            }
        }

        public void PlayerAction()
        {
            if (Console.KeyAvailable == false)
            {
                return;
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    if (MoveRightCheck() == true)
                    {
                        RightMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        map.map[posY, posX] = eMapState.PLAYER;
                        
                        
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.LeftArrow:
                    if (MoveLeftCheck() == true)
                    {
                        LeftMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.UpArrow:
                    if (MoveUPCheck() == true)
                    {
                        UPMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.DownArrow:
                    if (MoveDownCheck() == true)
                    {
                        DownMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.Spacebar:
                    if (_boomCount <= _maxBoomCount && map.map[posY, posX] != eMapState.BOOM)
                    {
                        _boomCount++;
                        SetBoom();

                    }
                    
                    break;



            }

            

            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
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

        public void GetItem()
        {
            switch (map.map[posY,posX])
            {
                case eMapState.FIRELENGTHITEM:
                    _fireLength++;
                    break;
                case eMapState.BOOMPLUSITEM:
                    _maxBoomCount++;
                    break;
                    
            }
        }

        private void SetBoom()
        {
            map.map[posY, posX] = eMapState.BOOM;
            _boomQueue.Enqueue(new Boom(posX, posY, _fireLength, map));


        }

    }
}
