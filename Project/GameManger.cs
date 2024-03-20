using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private int _mNum;
        public bool b;


        public GameManger(Map map, Player player)
        {
            _mNum = 0;
            this.map = map;
            this.player = player;
            b=false;

        }

        public void SetPlayer()
        {
            map.map[player.posX, player.posY] = eMapState.PLAYER;
        }



        public bool ClearGame()
        {
            foreach (eMapState map in map.map)
            {
                if(map == eMapState.MONSTER || map == eMapState.BOX)
                {
                    return false;
                }

            }
            return true;
        }

        public void MonsterMove()
        {
            foreach(Monster monster in map.monsters.Values)
            {
                monster.Move();
            }
        }


        public bool PlayerDieCheck()
        {
            player.Die();

            if (player._dead == true)
            {
                map.map[player.posY, player.posX] = eMapState.MONSTER;
                return true;
            }
            else if (player._die == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void MonsterDingCheck()
        {
            Dictionary<string,Monster>m=new Dictionary<string,Monster>();
            foreach (Monster monster in map.monsters.Values)
            {
                monster.Die();
                if(monster._b == true)
                {
                    m.Add($"{monster._yKey},{monster._xKey}",monster);
                }
                
            }

            foreach (string s in m.Keys)
            {
                if (map.monsters.ContainsKey(s) == true)
                {
                    map.monsters.Remove(s);
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
