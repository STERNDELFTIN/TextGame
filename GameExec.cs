using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum Map { Lobby, Dungeon, Town }

    public class GameExec
    {
        private Map map = Map.Lobby;

        public void Process()
        {
            switch (map)
            {
                case Map.Lobby:
                    ProcessLobby();
                    break;
                case Map.Dungeon:
                    ProcessDungeon();
                    break;
                case Map.Town:
                    ProcessTown();
                    break;
                default:
                    continue;
            }
        }

        public static int StartTheGame()
        {
            Console.WriteLine("TextRPG에 오신 것을 환영합니다!");

            while (true)
            {
                Console.WriteLine("[1]로그인\n[2]회원가입\n[3]비밀번호 찾기\n[4]종료");
                Console.Write("입력# ");
                int.TryParse(Console.ReadLine(), out int input);
                Console.WriteLine();

                if (input <= 4 && input >= 1)
                    return input;
                else
                    Console.WriteLine("Select again, please.\n");
            }
        }

        public static void EnterTheGame(Dictionary<string, Player> player, string id)
        {
            Console.WriteLine($"[{id}]님이 접속했습니다!");
            Console.WriteLine("[1]마을 입장\n[2]던전 입장");
            while (true)
            {
                Console.Write("입력# ");
                int.TryParse(Console.ReadLine(), out int input);
                Console.WriteLine();

                if (input == 1)
                    new Town(player, id);
                else if (input == 2)
                    new Dungeon(player, id);
                else
                {
                    Console.WriteLine("Select again, please.\n");
                    continue;
                }
            }
        }

        public static void EndTheGame()
        {
            Console.WriteLine("게임을 종료합니다!");
        }

    }
}
