using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ConsoleTest
    {
        static void Main(string[] args)
        {
            Dictionary<string, Player> playersList = new Dictionary<string, Player>();
            Dictionary<string, string> account = new Dictionary<string, string>();
            // Monster monster = new Monster(); // 몬스터
            string id = "", password = "";
            bool b = false; // 반복문을 빠져나오기 위한 수단으로 사용

            static void WritePlayerInfo(Dictionary<string, Player> playersList, Dictionary<string, string> account)
            {
                Console.WriteLine();
                Console.WriteLine("[플레이어 정보]");
                foreach (KeyValuePair<string, Player> item in playersList)
                {
                    Console.Write($"아이디: {item.Key} ({item.Value})");
                    Console.WriteLine($" -> HP: {item.Value.HP}, STR: {item.Value.STR}, 직업: {item.Value.job}");
                    Console.WriteLine($"초기HP: {item.Value.InitHP}, 초기STR: {item.Value.InitSTR}, 총사용포인트: ");
                    Console.WriteLine($"EXP: {item.Value.EXP}, Level: {item.Value.Level}, 스탯포인트: {item.Value.Remaining_StatPoint}");
                }
                Console.WriteLine("[플레이어 계정]");
                foreach (KeyValuePair<string, string> item in account)
                {
                    Console.WriteLine($"아이디: {item.Key}, 비밀번호: {item.Value}");
                }
            }

            while ( true )
            {
                #region 로그인 및 계정생성
                while (true)
                {
                    b = false;
                    switch (GameExec.StartTheGame())
                    {
                        case 1: // 로그인
                            id = Account.Login(playersList, account);
                            if (id.Equals(""))
                                continue;
                            b = true;
                            break;
                        case 2: // 회원가입
                            id = Account.CreateID(playersList);
                            password = Account.CreatePassword();

                            // 직업 선택 여부
                            if (Job.WhetherSelectJob() == false)
                            {
                                Console.WriteLine("Select again, please.\n");
                                continue;
                            }

                            playersList.Add(id, new Player(id));
                            account.Add(id, password);

                            // 직업 선택
                            while (true)
                            {
                                Job.JobType jobChoice = Job.SelectJobType();
                                if (jobChoice == Job.JobType.UNKNOWN)
                                {
                                    Console.WriteLine("Select again, please.\n");
                                    continue;
                                }
                                Job.SelectJob(jobChoice, id, playersList);
                                break;
                            }
                            break;
                        case 3: // 비밀번호 찾기
                                // Account.FindAccount(account):
                            break;
                        case 4: // 종료
                            GameExec.EndTheGame();
                            return;
                        default:
                            Console.WriteLine("Select again, please.\n");
                            continue;
                    }

                    if (b == true)
                        break;
                }
                #endregion

                #region 게임 입장
                while (true)
                {
                    WritePlayerInfo(playersList, account); // 플레이어 정보 (나중에 지움)
                    Console.WriteLine();
                    GameExec.EnterTheGame(id);

                    // 테스트
                    playersList[id].EXPUP();
                    Console.WriteLine($"Level: {playersList[id].Level}, EXP: {playersList[id].EXP}\n");
                    playersList[id].LevelUp();
                    Console.WriteLine($"Level: {playersList[id].Level}, EXP: {playersList[id].EXP}\n");



                    WritePlayerInfo(playersList, account); // 플레이어 정보 (나중에 지움)
                    break;
                }
                #endregion


                Console.WriteLine();
                Console.Write("1을 입력하면 종료# ");
                int.TryParse(Console.ReadLine(), out int input);
                if (input == 1)
                    break;
            }
        }
    }
}
