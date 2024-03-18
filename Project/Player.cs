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
        List<Boom> _boom;
        Queue<Boom> _boomQueue;

        private int _fireLength;
        private int _boomCount;

        public int fireLength { get { return _fireLength; } set { _fireLength = value; } }
        public int boomCount { get { return _boomCount; } set { _boomCount = value; } }
        public List<Boom> boom { get { return _boom; } set { _boom = value; } }
        public Queue<Boom> boomq { get { return _boomQueue; } set { _boomQueue = value; } }

        public Player(Map map) : base(10)
        {
            this.map = map;
            _boom = new List<Boom>();
            _boomQueue = new Queue<Boom>();
            posX = 10;
            posY = 10;
            beforePosX = posX;
            beforePosY = posY;
            _fireLength = 4;
            _boomCount = 1;
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
                    if (map.map[posY, (posX) + 1] == eMapState.NULL || map.map[posY , posX + 1] == eMapState.ITEM)
                    {
                        RightMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        map.map[posY, posX] = eMapState.PLAYER;
                       
                        
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.LeftArrow:
                    if (map.map[posY, (posX) - 1] == eMapState.NULL || map.map[posY , posX - 1] == eMapState.ITEM)
                    {
                        LeftMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.UpArrow:
                    if (map.map[(posY) - 1, posX] == eMapState.NULL || map.map[posY - 1, posX] == eMapState.ITEM)
                    {
                        UPMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.DownArrow:
                    if (map.map[posY + 1, posX] == eMapState.NULL || map.map[posY + 1, posX] == eMapState.ITEM)
                    {
                        DownMove();
                        if (map.map[beforePosY, beforePosX] != eMapState.BOOM)
                        {
                            map.map[beforePosY, beforePosX] = eMapState.NULL;
                        }
                        map.map[posY, posX] = eMapState.PLAYER;
                        break;
                    }
                    else
                    {
                        return;
                    }
                case ConsoleKey.Spacebar:
                    SetBoom();
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
            moveCount--;
        }
        public void LeftMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posX--;
            moveCount--;
        }
        public void UPMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY--;
            moveCount--;
        }
        public void DownMove()
        {
            beforePosX = posX;
            beforePosY = posY;
            posY++;
            moveCount--;
        }

        private void SetBoom()
        {
            map.map[posY, posX] = eMapState.BOOM;
            _boomQueue.Enqueue(new Boom(20, posX, posY, _fireLength, map));


        }

    }
}
