using System.Drawing;

namespace Project
{

    public enum eMapState
    {
        NULL, BOX, ITEM, PLAYER, MONSTER, BOOM, WILL
    }
    public class Map
    {
        private Unit unit;
        private eMapState[,] _map;
        private eMapState[,] _bufferMap;

        public Map(int xSize, int ySize)
        {
            _map = new eMapState[xSize, ySize];
            _bufferMap = new eMapState[xSize, ySize];
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

        public void BufferPrint()
        {
            /* 현재 미로와 front_buffer(이전 미로)에 있는 미로 비교 */
            for (int i = 0; i < _bufferMap.GetLength(0); i++)
            {
                for (int j = 0, j2 = 0; j < _bufferMap.GetLength(1); j++)
                {
                    if (_bufferMap[i,j] != _map[i,j])
                    {
                        PrintMap(i, j);
                        // 바뀐 부분 화면에 출력
                        _bufferMap[i, j] = _map[i, j];
                        // 바뀐 부분은 출력 후 front_buffer에 저장
                    }
                    //j2 += 2;
                    // 2byte(두칸)짜리로 출력하기 때문에 x 좌표는 2칸씩 이동시켜야함
                }
            }
        }

        public void PrintMap(int i, int j)
        {
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
            }
        }


        public virtual void PrintMap()
        {
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
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("???");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
