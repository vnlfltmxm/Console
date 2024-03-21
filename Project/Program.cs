namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();
            Map f = new Map(5, 10);
            Player player = new Player(f, random.Next(1,f.map.GetLength(1) - 1), random.Next(1,f.map.GetLength(0) - 1));
            GameManger g = new GameManger(f, player);
            //Menu menu = new Menu();

            //    menu.Menu1();

            //Console.ReadLine();
            //    Console.Clear();
            

            player.SetPlayer();
            f.CreateMape();
            


            while (true)
            {
                f.PrintMap();
                player.PlayerAction();
                  g.MonsterMove();
                g.MonsterDieCheck();

                if (g.PlayerDieCheck() == true || g.ClearGame() == true)
                {
                    f.PrintMap();
                    break;
                }
                
            }
            

        }
    }
}
