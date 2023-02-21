using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal interface IJobInfo
    {
        public static new Job.JobType job { get; }
        public static new int jobNum { get; }
        public static new int HP { get; }
        public static new int STR { get; }

        static public void WriteJobInfo() { } // 직업정보 출력
    }
}
