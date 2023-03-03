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
                Console.WriteLine($"{StatNum}. {StatName}");
            }
        }

        protected string Name { get; private set; }
        protected int Level { get; private set; }
        protected int HP { get; private set; }
        protected int STR { get; private set; }

        public void Info() { }
        public class Rabbit : Monster
        {
            protected new string Name { get; private set; } = "Rabbit";
            protected new int Level { get; private set; } = 1;
            protected new int HP { get; private set; } = 10;
            protected new int STR { get; private set; } = 1;
            
            public void Info()
            {
                Console.WriteLine($"LV{Level} [{Name}] HP: {HP}, STR: {STR}");
            }
        }
        public class Wolf : Monster
        {
            protected new string Name { get; private set; } = "Wolf";
            public new int Level { get; private set; } = 2;
            public new int HP { get; private set; } = 30;
            public new int STR { get; private set; } = 5;

            public void Info()
            {
                Console.WriteLine($"LV{Level} [{Name}] HP: {HP}, STR: {STR}");
            }
        }

        public class Slime : Monster
        {
            protected new string Name { get; private set; } = "Slime";
            public new int Level { get; private set; } = 3;
            public new int HP { get; private set; } = 40;
            public new int STR { get; private set; } = 8;

            public void Info()
            {
                Console.WriteLine($"LV{this.Level} [{Name}] HP: {HP}, STR: {STR}");
            }
        }

    }
}
