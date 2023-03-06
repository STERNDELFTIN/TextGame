using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum Map { Lobby, Dungeon, Town }
    
    // 게임 실행
    public class GameExec
    {
        private Map map = Map.Lobby;

        public bool Process()
        {
            switch (map)
            {
                case Map.Lobby:
                    return ProcessLobby();
                case Map.Dungeon:
                    ProcessDungeon();
                    break;
                case Map.Town:
                    ProcessTown();
                    break;
            }
            return true;
        }

        public static bool ProcessLobby()
        {
            string id;

            while (true)
            {
                Console.WriteLine("TextRPG에 오신 것을 환영합니다!");
                Console.WriteLine("[1]로그인\n[2]회원가입\n[3]비밀번호 찾기\n[4]종료");
                Console.Write("입력# ");
                int.TryParse(Console.ReadLine(), out int input);
                Console.WriteLine();

                // wrong input
                if (input > 4 || input < 1)
                {
                    Console.WriteLine("Select again, please.\n");
                    continue;
                }
                
                switch (input)
                {
                    #region 로그인
                    case 1: // 로그인
                        id = Account.Login() ?? "";
                        if (id.Equals(""))
                            continue;
                        EnterTheGame(id);
                        break;
                    #endregion
                    #region 회원가입
                    case 2: // 회원가입
                        id = Account.CreateAccount() ?? "";
                        if (id.Equals(""))
                            continue;
                        break;
                    #endregion
                    #region 비밀번호 찾기
                    case 3: // 비밀번호 찾기
                        id = Account.FindAccount() ?? "";
                        if (id.Equals(""))
                            continue;
                        break;
                    #endregion
                    #region 종료
                    case 4: // 종료
                        GameExec.EndTheGame();
                        return false;
                    #endregion
                }
            }
        }

        private static void EnterTheGame(string id)
        {
            Dungeon dungeon;
            Town town;

            Console.WriteLine($"[{id}]님이 접속했습니다!");
            Console.WriteLine("[1]마을 입장\n[2]던전 입장");
            while (true)
            {
                Console.Write("입력# ");
                int.TryParse(Console.ReadLine(), out int input);
                Console.WriteLine();

                if (input == 1)
                    new Town(id);
                else if (input == 2)
                    Dungeon.EnterTheDungeon(id);
                else
                {
                    Console.WriteLine("Select again, please. 잘못된 숫자를 입력하셨습니다..\n");
                    continue;
                }
                break;
            }
        }

        private static void ProcessDungeon()
        {

        }

        private static void ProcessTown()
        {

        }

        public static void EndTheGame()
        {
            Console.WriteLine("게임을 종료합니다!");
        }

    }
}
