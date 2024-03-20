namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map f = new Map(10, 10);
            Player player = new Player(f);
            GameManger g = new GameManger(f, player);

            g.SetPlayer();
            f.CreateMape();
            


            while (true)
            {
                f.PrintMap();
                player.PlayerAction();
                g.Check();
                g.MonsterMove();
                g.MonsterDingCheck();

                if (g.PlayerDieCheck() == true || g.ClearGame() == true)
                {
                    f.PrintMap();
                    break;
                }
                
            }
            

        }
    }
}
