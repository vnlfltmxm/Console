using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Item
    {
        public void SetFireLengthItem(Map map,int posX,int posY)
        {
            map.map[posY, posX] = eMapState.FIRELENGTHITEM;
        }

        public void SetBoomPlusItem(Map map, int posX, int posY)
        {
            map.map[posY, posX] = eMapState.BOOMPLUSITEM;
        }
    }
}
