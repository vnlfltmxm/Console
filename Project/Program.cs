using System.Diagnostics;
using System.Timers;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();
            Map map = new Map(15, 15);
            Player player = new Player(map, random.Next(1,map.map.GetLength(1) - 1), random.Next(1,map.map.GetLength(0) - 1));
            GameManger gm = new GameManger(map, player);
            Menu menu = new Menu();
            PrintManger pm=new PrintManger(map,player);

            Console.SetWindowSize(100, 60);

            pm.PrintAnime();

            while (true)
            {
                pm.PrintLogo();
                pm.PrintMenu();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                    break;
                else
                {
                    Console.Clear();
                    continue;
                }

            }
            Console.Clear();
            player.SetPlayer();
            map.CreateMape();
            pm.PrintControl();



            while (true)
            {
                pm.PrintMap();
                pm.PrintState();
                player.PlayerAction();
                gm.MonsterMove();
                gm.MonsterDieCheck();

                if (gm.PlayerDieCheck() == true || gm.ClearGame() == true)
                {
                    pm.PrintMap();
                    Thread.Sleep(2000);

                }

                if (gm.gameClear == true)
                {
                    Console.Clear();
                    pm.PrintGameClear();
                    break;
                }

                if (gm.gameOver == true)
                {
                    Console.Clear();
                    pm.PrintGameOver();
                    break;
                }

            }
        }
    }
}
