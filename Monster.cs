using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Monster
    {
        public enum MonsterType { None, Rabbit, Wolf, Slime } // 몬스터 타입을 열거형으로 정렬
        public enum StatType { 레벨 = 1, 체력 = 2, 데미지 = 3 }
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

        public class Rabbit
        {

        }
        public class Wolf
        {

        }

        public class Slime
        {

        }

    }
}
