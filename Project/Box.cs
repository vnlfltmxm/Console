using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Box
    {
        private int _posX;
        private int _posY;

        private Item _item;

        public Box()
        {
            _item = new Item();
        }


        public void DistroyBox(Map map,int posX,int posY)
        {
            Random random = new Random();

            if (random.Next(0, 100) < 10)
            {
                _item.SetFireLengthItem(map, posX, posY);
            }
            else if (random.Next(0, 100) < 20)
            {
                _item.SetBoomPlusItem(map, posX, posY);
            }
            else if (random.Next(0, 100) < 40) 
            {
                if (map.monsters.ContainsKey($"{posY},{posX}") == false)
                {
                    map.monsters.Add($"{posY},{posX}", new Monster(posX, posY, map));
                }
            }
            else
            {
                map.map[posY, posX] = eMapState.NULL;
            }
        }
    }
}
