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
            for (int i = 0; i < StatusTypeSize(); i++)
            {
                 name = Enum.GetName(typeof(StatusType), i);
                Console.WriteLine($"{i + 1}. {name}");
            }
            Console.WriteLine(Enum.GetNames(typeof(StatusType))); 
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
        public int StatPoint { get; private set; } = 0; // 초기 StatPoint = 0
        // public int money = 0; //보유하고 있는 돈

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
            StatPoint += 5;
            UseStatPoint();
        }
        public void UseStatPoint() // 스탯 포인트 사용
        {
            while (true)
            {
                Console.WriteLine($"스탯 포인트 {StatPoint}가 있습니다. 스탯 포인트를 사용하시겠습니까? (Y/N)");
                Console.Write("입력# ");
                char input = Convert.ToChar(Console.ReadLine());
                if (input.Equals('Y'))
                {
                    Console.WriteLine("투자하고 싶은 능력치의 번호를 입력하시오.");
                    StatusTypeList();
                    while (true)
                    {
                        while (StatPoint > 0)
                        {
                            Console.Write("현재 상태창");
                            Console.WriteLine($" [ 체력: {HP}, 데미지: {STR}, 보유 포인트: {StatPoint} ]");
                            Console.Write("입력# ");
                            //Console.Write($"[잔여 포인트: {StatPoint}] 투자할 능력치 >> ");
                            int.TryParse(Console.ReadLine(), out int usePoint);
                            //int UsePoint = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();
                            if (usePoint == (int)StatusType.HP)
                                Console.WriteLine($"포인트 1을 사용하여 [체력]이 1 증가하였습니다! ({HP} -> {++HP})");
                            else if (usePoint == (int)StatusType.STR)
                                Console.WriteLine($"포인트 1을 사용하여 [데미지]가 1 증가하였습니다! ({STR} -> {++STR})");
                            else
                                Console.WriteLine("다시 입력해주세요.");

                            StatPoint--;
                            Console.WriteLine();
                        }
                        break;
                    }
                }
                else if (input.Equals('N'))
                    break;
                else
                {
                    Console.WriteLine("잘못된 답변을 하셨습니다. 다시 입력해주세요.");
                    continue;
                }
                break;
            }
        }
        public void InitStatPoint() // 스탯 초기화
        {
            /// 스탯 사용 전의 데이터를 저장해야 됨.
            // HP, Damage, StatPoint에 변화
            int initHP = Level;
            // int initDamage = ;
            // int initStatPoint = ;
        }
        #endregion
        public string ToString()
        {
            return $"ID {ID}, job {job}, HP {HP}, STR {STR}";
        }

    }
}

