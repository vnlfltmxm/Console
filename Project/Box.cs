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

        public bool bo;

        private Item _item;
        Monster _monster; 

        public Box()
        {
            bo = false;
            _item = new Item();
        }


        public void DistroyBox(Map map,int posX,int posY)
        {
            Random random = new Random();

            if (random.Next(0, 100) < 5)
            {
                _item.SetFireLengthItem(map, posX, posY);
            }
            else if(random.Next(0, 100) < 10)
            {
                _item.SetBoomPlusItem(map, posX, posY);
            }
            else
            {
                map.map[posY, posX] = eMapState.MONSTER;
                Console.WriteLine($"{posX},{posY}");
            }
        }
    }
}
