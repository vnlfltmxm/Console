using System.Drawing;

namespace Project
{

    public enum eMapState
    {
        NULL, BOX, FIRELENGTHITEM, PLAYER, MONSTER, BOOM, WILL,FIRE,BOOMPLUSITEM
    }
    public class Map
    {
        private eMapState[,] _map;
        private Dictionary<string, Box> _box;
        private Dictionary<string, Monster> _monster;
        //private List<Monster> _monsters;
        public Map(int xSize, int ySize)
        {
            _map = new eMapState[xSize, ySize];
            _box = new Dictionary<string, Box>();
            _monster = new Dictionary<string, Monster>();
            //_monsters= new List<Monster>();
    }

        public eMapState[,] map { get { return _map; } set { _map = value; } }
        public Dictionary<string, Box> box { get {  return _box; } set { _box = value; } }
        //public List<Monster> monsters { get { return _monsters; } set { _monsters = value; } }
        public Dictionary<string, Monster> monsters { get { return _monster; } set {  monsters = value; } }

        public bool PlayerCheck(int posX,int posY)
        {
            if (map[posY, posX + 1] == eMapState.PLAYER)
                return true;
            if (map[posY, posX - 1] == eMapState.PLAYER)
                return true;
            if (map[posY+1, posX] == eMapState.PLAYER)
                return true;
            if (map[posY-1, posX + 1] == eMapState.PLAYER)
                return true;

            return false;

        }


        public void CreateMape()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] != eMapState.PLAYER)
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
                        else if (random.Next(0, 100) < 30 && PlayerCheck(j,i) == false)
                        {
                            _map[i, j] = eMapState.BOX;
                            _box.Add($"{i},{j}", new Box());
                        }
                        else
                        {
                            _map[i, j] = eMapState.NULL;
                        }
                    }
                    
                }
            }
        }
        

        public void MapCheck()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == eMapState.FIRE && box.ContainsKey($"{i},{j}") == true)
                    {
                        box[$"{i},{j}"].DistroyBox(this, j, i);
                        box.Remove($"{i},{j}");
                    }

                }
            }
        }

        public void MapClear()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == eMapState.FIRE)
                    {
                        map[i, j] = eMapState.NULL;
                    }

                }
            }

            
        }

       
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
                        case eMapState.FIRELENGTHITEM:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("$ ");
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
                        case eMapState.BOOMPLUSITEM:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("↑");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.ResetColor();
                Console.WriteLine();
                
            }
            
        }
    }
}
