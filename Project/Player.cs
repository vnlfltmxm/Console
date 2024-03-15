using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Player: Unit
    {
        public Player() : base(10)
        {
            posX = 10;
            posY = 10;
            beforePosX = posX;
            beforePosY = posY;
        }

        public void Move()
        {
            beforePosX = posX;
            beforePosY = posY;

            ConsoleKeyInfo key = Console.ReadKey(true);
            
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    posX++;
                    break;
            }
        }
    }
}
