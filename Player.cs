using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Job;

namespace TextRPG
{
    public class Player
    {
        const int MAX_EXP = 10;
        public enum StatusType { UNKNOWN, HP, STR }

        static int StatusTypeSize() // Status 개수
        {
            int count;
            count = Enum.GetValues(typeof(StatusType)).Length;
            return count;
        }
        static void StatusTypeList() // Status 이름
        {
            string name;
            for (int i = 0; i < StatusTypeSize() - 1; i++)
            {
                 name = Enum.GetName(typeof(StatusType), i + 1);
                Console.WriteLine($"{i + 1}. {name}");
            }
        }

        public Job.JobType job = Job.JobType.UNKNOWN;
        public int jobNum = (int)Job.JobType.UNKNOWN;
        public int InitHP { get; protected set; } = 0;
        public int InitSTR { get; protected set; } = 0;

        public int HP { get; set; } = 0;
        public int STR { get; set; } = 0;

        public string ID { get; set; }

        public int EXP { get; private set; } = 0; // 초기 EXP = 0
        public int Level { get; private set; } = 1; // 초기 Level = 1
        public int Remaining_StatPoint { get; private set; } = 0; // 초기 StatPoint = 0
        public int Total_StatPoint { get; private set; } = 0;
        // public int Money = 0; //보유하고 있는 돈

        public Player(string ID) { this.ID = ID; }
        public Player(Job.JobType job)
        {
            this.job = job;
        }
        public void SetInitStatus(int init_HP, int init_STR)
        {
            this.InitHP = init_HP;
            this.InitSTR = init_STR;
        }
        public void SetStatus(int HP, int STR)
        {
            this.HP = HP;
            this.STR = STR;
        }

        #region 경험치 및 레벨
        public void EXPUP()
        {
            // EXP의 MAX 값 = 10
            EXP += 2;
            if (EXP >= MAX_EXP)
            {
                EXP = EXP - MAX_EXP;
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Level += 1;
            Remaining_StatPoint += 5;
            Total_StatPoint += 5;
            UseStatPoint();
        }
        public void UseStatPoint() // 스탯 포인트 사용
        {
            while (true)
            {
                Console.WriteLine($"스탯 포인트 {Remaining_StatPoint}가 있습니다. 스탯 포인트를 사용하시겠습니까? (Y/N)");
                Console.Write("입력# ");
                char input = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();

                if (input.Equals('Y'))
                {
                    Console.WriteLine("[스탯 종류]");
                    StatusTypeList();
                    Console.WriteLine();
                    while (true)
                    {
                        while (Remaining_StatPoint > 0)
                        {
                            Console.WriteLine("[현재 상태창]");
                            Console.WriteLine($"HP: {HP}, STR: {STR}");
                            Console.Write($"입력(잔여포인트:{Remaining_StatPoint})# ");
                            int.TryParse(Console.ReadLine(), out int usePoint);
                            Console.WriteLine();

                            if (usePoint == (int)StatusType.HP)
                                Console.WriteLine($"포인트 1을 사용하여 [체력]이 1 증가하였습니다! ({HP} -> {++HP})");
                            else if (usePoint == (int)StatusType.STR)
                                Console.WriteLine($"포인트 1을 사용하여 [데미지]가 1 증가하였습니다! ({STR} -> {++STR})");
                            else
                            {
                                Console.WriteLine("다시 입력해주세요.\n");
                                continue;
                            }

                            Remaining_StatPoint--;
                            Console.WriteLine();
                        }
                        break;
                    }
                }
                else if (input.Equals('N'))
                    break;
                else
                {
                    Console.WriteLine("잘못된 답변을 하셨습니다. 다시 입력해주세요.\n");
                    continue;
                }
                break;
            }
        }
        public void ResetStat() // 스탯 초기화
        {
            // HP, STR, StatPoint에 변화
            HP = InitHP;
            STR = InitSTR;
            Remaining_StatPoint = Total_StatPoint;
        }
        #endregion

        public static void PrintPlayerList(Dictionary<string, Player> player, string id)
        {
            Console.WriteLine("[플레이어 정보]");
            Console.WriteLine($"아이디: {player[id].ID}\nhp: {player[id].HP}\nstr: {player[id].STR}\n레벨: {player[id].Level} ({player[id].EXP}*0.1%)\n잔여 포인트: {player[id].Remaining_StatPoint}");
        }
    }
}

