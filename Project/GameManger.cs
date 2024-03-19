using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;



namespace Project
{
    
    internal class GameManger
    {

        private Map map;
        private Player player;
        private List<Monster> monsters;
        private Dictionary<int, Monster> monster;
        private int _mNum;
        public bool b;
       // Queue<System.Timers.Timer> timer2; //= new System.Timers.Timer(3000);


        public GameManger(Map map, Player player)
        {
            //timer2 = new Queue<System.Timers.Timer>();
            _mNum = 0;
            monsters = new List<Monster>();
            monster = new Dictionary<int, Monster>();
            this.map = map;
            this.player = player;
            b=false;

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
        //public void SetMoveMonster()
        //{
        //    foreach (Monster m in monsters)
        //    {
        //        map.map[m.beforePosY, m.beforePosX] = eMapState.NULL;
        //        map.map[m.posY, m.posX] = eMapState.MONSTER;
        //    }
        //}
        public void RespownM(int posX,int posY,int Num, Map map)
        {
            monster.Add(_mNum, new Monster(posX,posY,map,_mNum));
            
            
           
        }
        //public void Explosion()
        //{
        //    UPEX();
        //    DownEX();
        //    RightEX();
        //    LeftEX();

        //    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        //    timer.Start();



        //}
        public void BoomEvent()
        {
            foreach(Boom boom in player.boomq)
            {
                if (boom != null && boom._c == false)
                {
                    boom.DownTimer();
                }
            }
            Check();

        }
       // public void timer_Elapsed2(object sender, ElapsedEventArgs e)
       // {
          //  player.boomq.Dequeue().Explosion();
          //  b = true;
            //map.PrintMap();

            //timer2.Peek().AutoReset = false;
            //timer2.Dequeue();
        //}
        public void MonsterCheck()
        {
            int c = 0;

            foreach(eMapState s in map.map)
            {
                if (s == eMapState.MONSTER)
                    c++;

            }

            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    if (map.map[i, j] == eMapState.MONSTER && c > monster.Count&&monster.ContainsKey(_mNum)==false) 
                    {
                        RespownM(j,i,_mNum,map);
                        _mNum++;
                        Console.WriteLine("sss");
                        Thread.Sleep(1000);
                    }

                }
            }


            foreach(Monster m in monster.Values)
            {
                if (m != null)
                m.Die();

                
                    
            }

            int n=monster.Count;

            for (int j = 0; j <= n; j++)
            {
                if (monster.ContainsKey(j) == true)
                {
                    monster.Remove(j);
                }

            }


        }
        public void MapClear()
        {
            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    if (map.map[i, j] == eMapState.FIRE)
                    {
                        map.map[i, j] = eMapState.NULL;
                    }
                   
                }
            }
        }

        public void PlayerItem()
        {
            switch (map.map[player.posY, player.posX])
            {
                case eMapState.FIRELENGTHITEM:
                    player.fireLength++;
                    break;
            }
        }

        public void Check()
        {

            try
            {
                foreach (Boom boom in player.boomq)
                {
                    if (boom != null && boom._ex == true)
                    {
                        player.boomq.Dequeue();
                        player.boomCount--;
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
