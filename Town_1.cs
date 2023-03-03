using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Town_1
    {
        string id;
        public Town_1(Dictionary<string, Player> player, string id)
        {
            this.id = id;
        }
        public struct pos
        {
            public int x;
            public int y;
        }
        // 1: 벽, 0: 지나갈 수 있는 공간, 3: 나의위치
        public string MapName { get; set; } = "Town";
        public int[,] tiles =
        {
            {1, 3, 1, 1, 1 },
            {1, 0, 0, 0, 1 },
            {1, 0, 0, 0, 1 },
            {1, 0, 0, 0, 1 },
            {1, 1, 1, 0, 1 }
        };

        public void Move()
        {

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[y, x] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (tiles[y, x] == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('\u25cf');
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("엔터키 입력");
                    break;
                case ConsoleKey.UpArrow:
                    Console.WriteLine("위키 입력");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("아래키 입력");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("왼쪽키 입력");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("오른쪽키 입력");
                    break;

            }
        }
    }
}
