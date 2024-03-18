using System.Drawing;

namespace Project
{

    public enum eMapState
    {
        NULL, BOX, ITEM, PLAYER, MONSTER, BOOM, WILL,FIRE
    }
    public class Map
    {
        private eMapState[,] _map;

        public Map(int xSize, int ySize)
        {
            _map = new eMapState[xSize, ySize];
        }

        public eMapState[,] map { get { return _map; } set { _map = value; } }

        public void CreateMape()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {

                    Random random = new Random();

                    if (i == 0 || i == _map.GetLength(0) - 1)
                    {
                        _map[i, j] = eMapState.WILL;
                    }
                    else if (j == 0 || j == _map.GetLength(1) - 1)
                    {
                        _map[i, j] = eMapState.WILL;
                    }
                    else if (random.Next(0, 100) < 30)
                    {
                        _map[i, j] = eMapState.BOX;
                    }
                    else
                    {
                        _map[i, j] = eMapState.NULL;
                    }

                }
            }
        }
        //public virtual void PrintMap(int posY, int posX, int Count)
        //{
        //    Console.SetCursorPosition(posX*2, posY);

        //    for (int i = 0; i < Count; i++)
        //    {
        //        Console.BackgroundColor = ConsoleColor.Gray;
        //        if (map[posY + i, posX] == eMapState.NULL)
        //        {
        //            Console.SetCursorPosition(posX * 2, posY);
        //            //Console.ForegroundColor = ConsoleColor.Gray;
        //            Console.Write("??");
        //            Console.ResetColor();
        //        }
        //        //if (map[posY - i, posX] == eMapState.NULL)
        //        //{
        //        //    Console.ForegroundColor = ConsoleColor.Gray;
        //        //    Console.Write("!!");
        //        //    Console.ResetColor();
        //        //}
        //        //if (map[posY, posX + i] == eMapState.NULL)
        //        //{
        //        //    Console.ForegroundColor = ConsoleColor.Gray;
        //        //    Console.Write("!!");
        //        //    Console.ResetColor();

        //        //}
        //        //if (map[posY, posX - i] == eMapState.NULL)
        //        //{
        //        //    Console.ForegroundColor = ConsoleColor.Gray;
        //        //    Console.Write("!!");
        //        //    Console.ResetColor();

        //        //}

        //        //switch (_map[posY, posX])
        //        //{
        //        //    case eMapState.NULL:
        //        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        //        Console.Write("■");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.BOX:
        //        //        Console.ForegroundColor = ConsoleColor.White;
        //        //        Console.Write("■");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.ITEM:
        //        //        Console.ForegroundColor = ConsoleColor.Green;
        //        //        Console.Write("■");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.PLAYER:
        //        //        Console.ForegroundColor = ConsoleColor.Green;
        //        //        Console.Write("■");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.MONSTER:
        //        //        Console.ForegroundColor = ConsoleColor.Red;
        //        //        Console.Write("■");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.BOOM:
        //        //        Console.ForegroundColor = ConsoleColor.Black;
        //        //        Console.Write("●");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.WILL:
        //        //        Console.ForegroundColor = ConsoleColor.Black;
        //        //        Console.Write("▣");
        //        //        Console.ResetColor();
        //        //        break;
        //        //    case eMapState.FIRE:
        //        //        Console.ForegroundColor = ConsoleColor.DarkRed;
        //        //        Console.Write("♨");
        //        //        Console.ResetColor();
        //        //        break;
        //        //}
        //        //Console.ForegroundColor = ConsoleColor.Black;
        //        //Console.Write("a");
        //        //Console.WriteLine();
        //        //Console.ResetColor();
        //        }

        //    }

        public virtual void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    switch (_map[i, j])
                    {
                        case eMapState.NULL:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.BOX:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.ITEM:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.PLAYER:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.MONSTER:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.BOOM:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("●");
                            Console.ResetColor();
                            break;
                        case eMapState.WILL:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("▣");
                            Console.ResetColor();
                            break;
                        case eMapState.FIRE:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("♨");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("a");
                Console.WriteLine();
                Console.ResetColor();
            }
            
        }
    }
}
