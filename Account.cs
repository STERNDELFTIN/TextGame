using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Account
    {
        // [로그인]
        public static string Login(Dictionary<string, Player> playersList, Dictionary<string, string> account)
        {
            string id, password;
            bool IsExistID;
            /// int형으로 할 때, Console.Read()로 하면 아스키코드로 읽혀서 1을 입력하면 47이 나옴. 주의!

            while(true)
            {
                // 아이디 입력
                Console.Write("아이디# ");
                id = Console.ReadLine();
                if (id.Equals(""))
                    continue;
                // 비밀번호 입력
                Console.Write("비밀번호# ");
                password = Console.ReadLine();
                if (password.Equals(""))
                    continue;

                // 아이디 존재 여부 확인
                IsExistID = playersList.ContainsKey(id);
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
                            return "";
                    }
                }
                // 아이디 및 비밀번호 일치 여부 확인
                if (!password.Equals(account[id]))
                {
                    Console.WriteLine("아이디와 비밀번호가 일치하지 않습니다. 다시 입력해주세요.\n");
                    return "";
                }

                break;
            }
            return id;
        }

        #region 계정 생성
        // [아이디 만들기]
        public static string CreateID(Dictionary<string, Player> playersList)
        {
            string id;
            bool IsDuplicatedID; // 중복체크변수
            Console.WriteLine("[회원가입]");

            while(true)
            {
                Console.Write("아이디# ");
                id = Console.ReadLine();
                if (id.Equals(""))
                    continue;

                // id 중복 체크
                IsDuplicatedID = playersList.ContainsKey(id);
                if(!IsDuplicatedID)
                {
                    Console.WriteLine("사용 가능한 아이디 입니다.");
                    while(true)
                    {
                        Console.WriteLine("[1] 아이디 사용하기\n[2] 뒤로가기");
                        Console.Write("입력# ");
                        int.TryParse(Console.ReadLine(), out int input);
                        Console.WriteLine();
                        switch (input)
                        {
                            case 1: // 아이디 사용하기
                                return id;
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
        public static string CreatePassword()
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
        #endregion

        #region 계정 찾기
        public static void FindAccount(string id, Dictionary<string, string> account)
        {

        }
        #endregion
    }
}
