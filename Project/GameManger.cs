using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project
{
    
    internal class GameManger
    {

        private Map map;
        private Player player;
        private List<Monster> monsters;

        public GameManger(Map map, Player player)
        {
            monsters = new List<Monster>();
            this.map = map;
            this.player = player;

        }

        public void SetPlayer()
        {
            map.map[player.posX, player.posY] = eMapState.PLAYER;
        }

        //public void SetMovePlayer()
        //{
        //    ConsoleKeyInfo key = Console.ReadKey(true);

        //    switch (key.Key)
        //    {
        //        case ConsoleKey.RightArrow:
        //            if (map.map[player.posY, (player.posX) + 1] == eMapState.NULL)
        //            {
        //                player.RightMove();
        //                if (map.map[player.beforePosY, player.beforePosX] != eMapState.BOOM)
        //                {
        //                    map.map[player.beforePosY, player.beforePosX] = eMapState.NULL;
        //                }
        //                map.map[player.posY, player.posX] = eMapState.PLAYER;
        //                break;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        case ConsoleKey.LeftArrow:
        //            if (map.map[player.posY, (player.posX) - 1] == eMapState.NULL)
        //            {
        //                player.LeftMove();
        //                if (map.map[player.beforePosY, player.beforePosX] != eMapState.BOOM)
        //                {
        //                    map.map[player.beforePosY, player.beforePosX] = eMapState.NULL;
        //                }
        //                map.map[player.posY, player.posX] = eMapState.PLAYER;
        //                break;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        case ConsoleKey.UpArrow:
        //            if (map.map[(player.posY) - 1, player.posX] == eMapState.NULL)
        //            {
        //                player.UPMove();
        //                if (map.map[player.beforePosY, player.beforePosX] != eMapState.BOOM)
        //                {
        //                    map.map[player.beforePosY, player.beforePosX] = eMapState.NULL;
        //                }
        //                map.map[player.posY, player.posX] = eMapState.PLAYER;
        //                break;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        case ConsoleKey.DownArrow:
        //            if (map.map[player.posY + 1, player.posX] == eMapState.NULL)
        //            {
        //                player.DownMove();
        //                if (map.map[player.beforePosY, player.beforePosX] != eMapState.BOOM)
        //                {
        //                    map.map[player.beforePosY, player.beforePosX] = eMapState.NULL;
        //                }
        //                map.map[player.posY, player.posX] = eMapState.PLAYER;
        //                break;
        //            }
        //            else
        //            {
        //                return;
        //            }


        //    }



        //}
        public void SetMoveMonster()
        {
            foreach (Monster m in monsters)
            {
                map.map[m.beforePosY, m.beforePosX] = eMapState.NULL;
                map.map[m.posY, m.posX] = eMapState.MONSTER;
            }
        }
        public void RespownM()
        {
            monsters.Add(new Monster());
           
        }

        public void BoomEvent()
        {
            
                player.boomq.Dequeue().DownTimer();
            //player.boomq.Dequeue().Explosion();

        }



    }
}
