using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TextRPG
{
    public class Job
    {
        #region 직업 타입
        public enum JobType { UNKNOWN, WARLORD, ARCHER, WIZARD } // 직업 타입을 열거형으로 정렬
        static int JobTypeSize() // 직업 개수
        {
            int count;
            count = Enum.GetValues(typeof(JobType)).Length;
            return count;
        }
        #endregion
        static public void JobList()
        {
            Warlord.WriteJobInfo();
            Archer.WriteJobInfo();
            Wizard.WriteJobInfo();
            Console.WriteLine();
        }

        static public bool WhetherSelectJob() // 직업 선택 여부
        {
            bool result = false;
            char selectAnswer;
            while (true)
            {
                Console.WriteLine("[직업 선택]");
                Console.WriteLine("직업을 선택하시겠습니까? (Y/N)");
                Console.Write("입력# ");
                selectAnswer = Convert.ToChar(Console.ReadLine());

                if (selectAnswer.Equals('N'))
                    break;
                else if (selectAnswer.Equals('Y'))
                {
                    result = true;
                    break;
                }
                else
                    Console.WriteLine("잘못된 답변을 하셨습니다. 다시 입력해주세요.\n");
            }
            Console.WriteLine();
            return result;
        }

        /// 반환형과 접근지정자를 맞춰주지 않았을 경우 에러가 발생함
        static public JobType SelectJobType() // 직업 타입 선택
        {
            Console.WriteLine("[직업 종류]");
            JobList();

            Console.WriteLine("원하는 직업의 번호를 입력하세요.");
            Console.Write("입력# ");
            string choice = Console.ReadLine();

            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    return JobType.WARLORD;
                case "2":
                    return JobType.ARCHER;
                case "3":
                    return JobType.WIZARD;
                default:
                    break;
            }
            return JobType.UNKNOWN;
        }

        /// https://winflahed.tistory.com/9 - 참고 (out, ref)
        public static void SelectJob(JobType choice, string id, Dictionary<string, Player> playersList )
        {
            switch (choice)
            {
                case JobType.WARLORD:
                    playersList[id] = new Warlord();
                    break;
                case JobType.ARCHER:
                    playersList[id] = new Archer();
                    break;
                case JobType.WIZARD:
                    playersList[id] = new Wizard();
                    break;
            }
            Console.WriteLine($"플레이어 [{id}]님의 직업은 [{playersList[id].job}] 입니다. 현재 체력은 [{playersList[id].HP}]이고, 데미지는 [{playersList[id].STR}] 입니다.\n");
        }
    }
}
