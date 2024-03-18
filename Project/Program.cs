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
                f.PrintMap();//플레이어 사방으로 박스 생성을 막아야함
                player.PlayerAction();
                if (player.boomq.Count > 0)
                {
                    g.BoomEvent();
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
