using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class Account
    {
        static Dictionary<string, Player> player = new Dictionary<string, Player>();
        static Dictionary<string, string> account = new Dictionary<string, string>();

        public static string ID { get; set; }
        public static string Password { get; set; }
        public static bool IsDuplicatedID;

        public static void WritePlayerInfo(Dictionary<string, Player> playersList, Dictionary<string, string> account)
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

        // [로그인]
        public static string? Login()
        {
            /// int형으로 할 때, Console.Read()로 하면 아스키코드로 읽혀서 1을 입력하면 47이 나옴. 주의!
            bool IsExistID;

            while(true)
            {
                #region 로그인 - 아이디 및 비번 입력
                Console.Write("아이디# ");
                ID = Console.ReadLine();
                if (ID.Equals(""))
                    continue;
                // 비밀번호 입력
                Console.Write("비밀번호# ");
                Password = Console.ReadLine();
                if (Password.Equals(""))
                    continue;
                #endregion

                #region 로그인 - 아이디, 비번 일치 확인
                // 아이디 존재 여부 확인
                IsExistID = player.ContainsKey(ID);
                if (!IsExistID)
                {
                    Console.WriteLine("존재하지 않는 아이디 입니다.");
                    Console.WriteLine("[1]다시 입력하기\n[2]로비로 가기");
                    Console.Write("입력# ");
                    int.TryParse(Console.ReadLine(), out int input);
                    Console.WriteLine();

                    switch(input)
                    {
                        case 1:
                            continue;
                        case 2:
                            GameExec.ProcessLobby();
                            break;
                        default:
                            Console.WriteLine("Select again, please. 잘못된 번호를 입력하셨습니다..\n");
                            continue;
                    }
                }
                // 아이디 및 비밀번호 일치 여부 확인
                if (!Password.Equals(account[ID]))
                {
                    Console.WriteLine("아이디와 비밀번호가 일치하지 않습니다. 다시 입력해주세요.\n");
                    return null;
                }
                #endregion

                break;
            }
            Console.WriteLine();
            return ID;
        }

        // [계정 생성]
        public static string? CreateAccount()
        {
            #region 계정 생성 - 아이디 만들기
            static string CreateID()
            {
                Console.WriteLine("[회원가입]");

                while (true)
                {
                    Console.Write("아이디# ");
                    ID = Console.ReadLine();
                    if (ID.Equals(""))
                        continue;

                    // id 중복 체크
                    IsDuplicatedID = player.ContainsKey(ID);
                    if (!IsDuplicatedID)
                    {
                        Console.WriteLine("사용 가능한 아이디 입니다.");
                        while (true)
                        {
                            Console.WriteLine("[1]아이디 사용하기\n[2]뒤로가기");
                            Console.Write("입력# ");
                            int.TryParse(Console.ReadLine(), out int input);
                            Console.WriteLine();
                            switch (input)
                            {
                                case 1: // 아이디 사용하기
                                    return ID;
                                case 2: // 뒤로가기
                                    break;
                                default:
                                    Console.WriteLine("Select again, please. 잘못된 번호를 입력하셨습니다..");
                                    continue;
                            }
                            break;
                        }
                    }
                    else
                        Console.WriteLine("이미 사용 중인 아이디 입니다.\n");
                }
            }
            #endregion

            #region 계정 생성 - 비밀번호 만들기
            static string CreatePassword()
            {
                string password;

                while (true)
                {
                    Console.Write("비밀번호# ");
                    password = Console.ReadLine();
                    if (password.Equals(""))
                        continue;
                    break;
                }
                Console.WriteLine();
                return password;
            }
            #endregion

            // [계정 생성]
            ID = CreateID();
            Password = CreatePassword();

            #region 직업 선택
            // 직업 선택 여부
            if (Job.WhetherSelectJob() == false)
            {
                Console.WriteLine("Select again, please. 직업 선택을 취소하셨습니다..\n");
                return null;
            }

            player.Add(ID, new Player(ID));
            account.Add(ID, Password);

            // 직업 선택
            while (true)
            {
                Job.JobType jobChoice = Job.SelectJobType();
                if (jobChoice == Job.JobType.UNKNOWN)
                {
                    Console.WriteLine("Select again, please. 잘못된 직업을 선택하셨습니다..\n");
                    continue;
                }
                Job.SelectJob(jobChoice, ID, player);
                break;
            }
            #endregion

            Console.WriteLine("계정이 생성되었습니다.");
            Console.WriteLine($"아이디: {ID}, 비밀번호: {Password}\n");
            return ID;
        }

        // [계정 찾기]
        public static string? FindAccount()
        {
            while (true)
            {
                Console.WriteLine("[비밀번호 찾기]");
                Console.WriteLine("아이디를 입력해주세요.");
                Console.Write("입력# ");
                ID =Console.ReadLine();
                if (ID.Equals(""))
                    continue;
                Console.WriteLine();

                #region 계정 찾기 - 아이디 존재 여부 확인
                IsDuplicatedID = player.ContainsKey(ID);
                if (!IsDuplicatedID)
                {
                    Console.WriteLine("존재하지 않는 아이디 입니다. 아이디를 다시 확인해주세요.\n");
                    return null;
                }
                #endregion

                Console.WriteLine($"비밀번호는 [{account[ID]}] 입니다.\n");
                GameExec.ProcessLobby();
            }
        }
    }
}
