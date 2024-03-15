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
            map.map[player.beforePosY, player.beforePosX] = eMapState.NULL;
            map.map[player.posY, player.posX] = eMapState.PLAYER;
        }
        public void SetMonster()
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
    }
}
