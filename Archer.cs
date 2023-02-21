using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Archer : Player, IJobInfo
    {
        public static new Job.JobType job = Job.JobType.ARCHER;
        public static new int jobNum = (int)Job.JobType.ARCHER;
        public static new int HP { get; private set; } = 75;
        public static new int STR { get; private set; } = 70;

        public Archer() : base(Job.JobType.ARCHER)
        {
            base.jobNum = Archer.jobNum;
            SetInitStatus(Archer.HP, Archer.STR);
            SetStatus(Archer.HP, Archer.STR);
        }

        static public void WriteJobInfo() // 직업 정보 출력
        {
            Console.WriteLine($"[{Archer.jobNum}] {Archer.job}\n" +
                $"HP = {Archer.HP}\n" +
                $"STR = {Archer.STR}");
        }
    }
}
