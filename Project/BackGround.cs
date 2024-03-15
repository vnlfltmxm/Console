namespace Project
{
    public class Filed
    {
        private int[,] filedSize;

        public Filed(int xSize, int ySize)
        {
            filedSize = new int[xSize, ySize];
        }

        public void PrintFiled()
        {
            for (int i = 0; i < filedSize.GetLength(0); i++)
            {
                for (int j = 0; j < filedSize.GetLength(1); j++)
                {
                    if (j == 0 || j == filedSize.GetLength(1) - 1)
                    {
                        Console.Write("■");
                    }
                    else if (i == 0 || i == filedSize.GetLength(0) - 1)
                    {
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();


            }
        }
    }
    class BackGround
    {
       
    }
}
