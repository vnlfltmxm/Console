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
        private bool _dead;



        public int fireLength { get { return _fireLength; } set { _fireLength = value; } }
        public int maxBoomCount { get { return _maxBoomCount; } set { _maxBoomCount = value; } }
        public int boomCount { get { return _boomCount; } set { _boomCount = value; } }
        public Queue<Boom> boomq { get { return _boomQueue; } set { _boomQueue = value; } }

        public bool dead { get { return _dead; } }

        public Player(Map map, int posX, int posY) : base(map, posX, posY)
        {
            this.map = map;
            _maxBoomCount = 1;
            _boomQueue = new Queue<Boom>();
            _fireLength = 2;
            _boomCount = 1;
            
        }
        public void SetPlayer()
        {
            map.map[posY, posX] = eMapState.PLAYER;
        }
        public void Die()
        {
            if (map.map[posY, posX] == eMapState.MONSTER)
            {
                _dead = true;
            }
            else if (map.map[posY, posX] == eMapState.FIRE)
            {
                die = true;
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
                    if (RightMoveCheck() == true)
                    {
                        RightMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        Die();
                        map.map[posY, posX] = eMapState.PLAYER;

                        
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.LeftArrow:
                    if (LeftMoveCheck() == true)
                    {
                        LeftMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        Die();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.UpArrow:
                    if (UPMoveCheck() == true)
                    {
                        UPMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        Die();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.DownArrow:
                    if (DownMoveCheck() == true)
                    {
                        DownMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        GetItem();
                        Die();
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.Spacebar:
                    CheckBoom();
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
            _boomQueue.Enqueue(new Boom(posX, posY, _fireLength,map));

        }

        public void CheckBoom()
        {

            try
            {
                foreach (Boom boom in boomq)
                {
                    if (boom != null && boom._ex == true)
                    {
                        boomq.Dequeue();
                        boomCount--;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }

    }
}
