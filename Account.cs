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

        #region 로그인
        // [로그인]
        public static string Login()
        {
            /// int형으로 할 때, Console.Read()로 하면 아스키코드로 읽혀서 1을 입력하면 47이 나옴. 주의!
            bool IsExistID;

            while(true)
            {
                // 아이디 입력
                Console.Write("아이디# ");
                ID = Console.ReadLine();
                if (ID.Equals(""))
                    continue;
                // 비밀번호 입력
                Console.Write("비밀번호# ");
                Password = Console.ReadLine();
                if (Password.Equals(""))
                    continue;

                // 아이디 존재 여부 확인
                IsExistID = player.ContainsKey(ID);
                if (!IsExistID)
                {
                    Console.WriteLine("존재하지 않는 아이디 입니다.");
                    Console.WriteLine("[1] 다시 입력하기\n[2] 뒤로가기");
                    Console.Write("입력# ");
                    int.TryParse(Console.ReadLine(), out int input);
                    Console.WriteLine();

                    switch(input)
                    {
                        case 1: default:
                            continue;
                        case 2:
                            return ""; // 확인해야하는 부분
                    }
                }
                // 아이디 및 비밀번호 일치 여부 확인
                if (!Password.Equals(account[ID]))
                {
                    Console.WriteLine("아이디와 비밀번호가 일치하지 않습니다. 다시 입력해주세요.\n");
                    return "";
                }

                break;
            }
            Console.WriteLine();
            return ID;
        }
        #endregion

        #region 계정 생성
        public static string CreateAccount()
        {
            // 아이디 만들기
            static string CreateID()
            {
                bool IsDuplicatedID; // 중복체크변수
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
                            Console.WriteLine("[1] 아이디 사용하기\n[2] 뒤로가기");
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
                                    Console.WriteLine("Select again, please.");
                                    continue;
                            }
                            break;
                        }
                    }
                    else
                        Console.WriteLine("이미 사용 중인 아이디 입니다.\n");
                }
            }

            // [비밀번호 만들기]
            static string CreatePassword()
            {
                string password;

                while (true)
                {
                    Console.Write("비밀번호# ");
                    password = Console.ReadLine();
                    if (password.Equals(null))
                        continue;
                    break;
                }
                Console.WriteLine();
                return password;
            }

            // [계정 생성 완료]
            ID = CreateID();
            Password = CreatePassword();

            // 직업 선택 여부
            if (Job.WhetherSelectJob() == false)
            {
                Console.WriteLine("Select again, please.\n");
                return "";
            }

            player.Add(ID, new Player(ID));
            account.Add(ID, Password);

            // 직업 선택
            while (true)
            {
                Job.JobType jobChoice = Job.SelectJobType();
                if (jobChoice == Job.JobType.UNKNOWN)
                {
                    Console.WriteLine("Select again, please.\n");
                    continue;
                }
                Job.SelectJob(jobChoice, ID, player);
                break;
            }
            return ID;
        }
        #endregion

        #region 계정 찾기
        public static void FindAccount(string id, Dictionary<string, string> account)
        {

        }
        #endregion
    }
}
