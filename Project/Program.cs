namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map f = new Map(30, 50);
            Player player = new Player();
            GameManger g = new GameManger(f, player);

            f.CreateMape();
               
            while (true)
            {
                g.SetPlayer();
               // f.PrintMap();//플레이어 사방으로 박스 생성을 막아야함
                f.BufferPrint();
                
                player.Move();
            }
            

        }
    }
}
