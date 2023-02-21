using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal interface IJobInfo
    {
        public static Job.JobType job { get; }
        public static int jobNum { get; }
        public static int HP { get; }
        public static int STR { get; }

        static public void WriteJobInfo() { } // 직업정보 출력
    }
}
