using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class GameExec
    {
        #region 게임시작
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
        #endregion

        #region 게임종료
        public static void EndTheGame()
        {
            Console.WriteLine("게임을 종료합니다.");
        }
        #endregion
    }
}
