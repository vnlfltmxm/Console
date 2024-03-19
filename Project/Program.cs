namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map f = new Map(30, 50);
            Player player = new Player(f);
            GameManger g = new GameManger(f, player);

            f.CreateMape();
            g.SetPlayer();   


            while (true)
            {
                f.PrintMap();
                g.MonsterCheck();
                //g.MapClear();
                player.PlayerAction();
                //g.MapCheck();
               

                if (player.boomq.Count > 0)
                {
                    g.BoomEvent();
                    g.Check();
                }
                
                

                if(f.map[player.posY, player.posX] == eMapState.FIRE)
                {
                    f.PrintMap();
                    break;
                }
                
            }
            

        }
    }
}
