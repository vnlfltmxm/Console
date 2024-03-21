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



        public GameManger(Map map, Player player)
        {
            this.map = map;
            this.player = player;

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
                monster.MoveAction();
            }
        }


        public bool PlayerDieCheck()
        {
            player.Die();

            if (player.dead == true)
            {
                map.map[player.posY, player.posX] = eMapState.MONSTER;
                return true;
            }
            else if (player.die == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void MonsterDieCheck()
        {
            Dictionary<string,Monster>m=new Dictionary<string,Monster>();

            foreach (Monster monster in map.monsters.Values)
            {
                monster.Die();
                if(monster.die == true)
                {
                    m.Add($"{monster.yKey},{monster.xKey}",monster);
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

        


    }
}
