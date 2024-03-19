using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Monster:Unit
    {
        Map map;
       public bool _b;
       public int _num;

        public Monster(int posX,int posY,Map map,int num) : base()
        {
            _b = false;
            _num = num;
            this.posY = posY;
            this.posX = posX;
            this.map = map;

            map.map[posY,posX]=eMapState.MONSTER;

            
        }

        public void Die()
        {
                    if (map.map[posY, posX] != eMapState.MONSTER )
                    {
                        _b = true; 
                        Console.WriteLine("!!!!!");
                        Thread.Sleep(1000);
                    }
            //if (map.map[posY, posX] == eMapState.PLAYER)
            //{
            //    _b = true;
            //    Console.WriteLine("!!!!!");
            //    Thread.Sleep(1000);
            //}
        }
    }
}
