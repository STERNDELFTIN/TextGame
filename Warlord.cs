using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Warlord : Player, IJobInfo
    {
        static public new Job.JobType job = Job.JobType.WARLORD;
        static public new int jobNum = (int)Job.JobType.WARLORD;
        static protected new int HP { get; private set; } = 90;
        static protected new int STR { get; private set; } = 50;

        public Warlord() : base(Job.JobType.WARLORD)
        {
            base.jobNum = Warlord.jobNum;
            SetInitStatus(Warlord.HP, Warlord.STR);
            SetStatus(Warlord.HP, Warlord.STR);
        }
        static public void WriteJobInfo() // 직업 정보 출력
        {
            Console.WriteLine($"[{Warlord.jobNum}] {Warlord.job}\n" +
                $"HP = {Warlord.HP}\n" +
                $"STR = {Warlord.STR}");
        }
    }

}
