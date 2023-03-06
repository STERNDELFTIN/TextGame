using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Monster
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
                Console.WriteLine($"{StatNum}. {StatName}");
            }
        }

        public string name = "";
        public int level = 0;
        public int hp = 0;
        public int str = 0;

        public void Info()
        {
            Console.WriteLine($"LV{level} [{name}] HP: {hp}, STR: {str}");
        }

        public class Rabbit : Monster
        {
            public Rabbit()
            {
                base.name = "Rabbit";
                base.level = 1;
                base.hp = 10;
                base.str = 1;
            }
        }
        public class Wolf : Monster
        {
            public Wolf()
            {
                base.name = "Wolf";
                base.level = 2;
                base.hp = 30;
                base.str = 5;
            }
        }
        public class Slime : Monster
        {
            public Slime()
            {
                base.name = "Slime";
                base.level = 3;
                base.hp = 50;
                base.str = 6;
            }
        }
    }
}
