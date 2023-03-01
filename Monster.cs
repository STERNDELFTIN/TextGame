using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Monster
    {
        public enum MonsterType { Unknown, Rabbit, Wolf, Slime } // 몬스터 타입을 열거형으로 정렬
        public enum StatType { Level = 1, HP = 2, STR = 3 }
        public static int StatTypeSize()
        {
            int count = System.Enum.GetValues(typeof(StatType)).Length;
            return count;
        }
        static void StatTypeName()
        {
            string StatName;
            for (int StatNum = 1; StatNum < StatTypeSize() + 1; StatNum++)
            {
                StatName = Enum.GetName(typeof(StatType), StatNum);
                System.Console.WriteLine($"{StatNum}. {StatName}");
            }
        }
        protected int Level { get; set; }
        protected int HP { get; set; }
        protected int STR { get; set; }

        public class Rabbit : Monster
        {
            protected new int Level { get; set; } = 1;
            protected new int HP { get; set; } = 10;
            protected new int STR { get; set; } = 1;

        }
        public class Wolf : Monster
        {
            protected new int Level { get; set; } = 2;
            protected new int HP { get; set; } = 30;
            protected new int STR { get; set; } = 5;
        }

        public class Slime : Monster
        {
            protected new int Level { get; set; } = 3;
            protected new int HP { get; set; } = 40;
            protected new int STR { get; set; } = 8;
        }

    }
}
