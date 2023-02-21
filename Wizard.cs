using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Wizard : Player, IJobInfo
    {
        public static new Job.JobType job = Job.JobType.WIZARD;
        public static new int jobNum = (int)Job.JobType.WIZARD;
        public static new int HP { get; private set; } = 20;
        public static new int STR { get; private set; } = 80;

        public Wizard() : base(Job.JobType.WIZARD)
        {
            base.jobNum = Wizard.jobNum;
            SetInitStatus(Wizard.HP, Wizard.STR);
            SetStatus(Wizard.HP, Wizard.STR);
        }

        static public void WriteJobInfo() // 직업 정보 출력
        {
            Console.WriteLine($"[{Wizard.jobNum}] {Wizard.job}\n" +
                $"HP = {Wizard.HP}\n" +
                $"STR = {Wizard.STR}");
        }
    }
}
