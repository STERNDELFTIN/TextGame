using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Monster;

namespace TextRPG
{
    public class Dungeon
    {
        public enum DungeonType { Begginer, Intermediate, Advanced }

        static Random rand = new Random();

        public static void EnterTheDungeon(string id)
        {
            Monster mon;
            Console.WriteLine("[초심자의 던전]");
            Console.WriteLine("초급 던전에 입장하셨습니다.");

            while (true)
            {
                Console.WriteLine("앞으로 전진하시겠습니까? 앞으로 전진을 할시에는 '1'을 입력해주세요.");
                Console.Write("입력# ");
                int.TryParse(Console.ReadLine(), out int input);
                Console.WriteLine();

                if (input == 1)
                {
                    Console.WriteLine("앞으로 1칸 전진하셨습니다.");
                    mon = CreateMonster();
                    if (mon.Equals(null))
                        continue;
                    PVE(id, mon);
                }
                else
                {
                    Console.WriteLine("Select again, please. 잘못된 숫자를 입력하셨습니다..\n");
                    continue;
                }
                break;
            }
        }

        public static Monster CreateMonster()
        {
            Monster? mon = null;
            
            int randMon = rand.Next(1, 6); // 50%의 확률로 몬스터 등장
            string monName = Enum.GetName(typeof(StatType), randMon);

            switch (randMon)
            {
                case (int)MonsterType.Rabbit:
                    mon = new Rabbit();
                    mon.Info();
                    return mon;
                case (int)MonsterType.Wolf:
                    mon = new Wolf();
                    mon.Info();
                    return mon;
                case (int)MonsterType.Slime:
                    mon = new Slime();
                    mon.Info();
                    return mon;
            }
            return null;
        }

        public static void PVE(string id, Monster mon)
        {
            static void PlayerAttackMonster(string id, Monster mon)
            {
                mon.hp -= Account.player[id].STR;
                Console.WriteLine($"{mon.name}의 hp: {mon.hp}");
                Console.WriteLine($"[{Account.player[id].ID}]의 hp: {Account.player[id].HP}");
            }
            static void PlayerIsAttackedMonster(string id, Monster mon)
            {
                Account.player[id].HP -= mon.str;
                Console.WriteLine($"{mon.name}의 hp: {mon.hp}");
                Console.WriteLine($"[{Account.player[id].ID}]의 hp: {Account.player[id].HP}");
            }
            static void PlayerRunAwayFromMonster()
            {
                Console.WriteLine("몬스터가 공격하려는 순간, 당신은 몬스터의 공격을 피하고 겨우 도망쳤습니다!");
            }

            Console.WriteLine("헉! 길을 걷다가 몬스터를 조우했습니다!");
            Console.WriteLine("당신은 어떠한 행동을 하시겠습니까?");
            while (true)
            {
                Console.WriteLine("[1]공격하기\n[2]도망가기\n");
                int.TryParse(Console.ReadLine(), out int input);

                if (input == 1)
                    PlayerAttackMonster(id, mon);
                else if (input == 2)
                {
                    int sucess_runAway = rand.Next(1, 100); // 도망칠 확률 조정
                    switch (sucess_runAway)
                    {
                        case int n when (n >= 1 && n <= 50): // 도망 성공
                            PlayerRunAwayFromMonster();
                            break;
                        default: // 도망 실패
                            Console.WriteLine("'저런.. 도망가려는 순간, 몬스터는 당신을 공격하여 도망을 실패하셨습니다.");
                            PlayerIsAttackedMonster(id, mon);
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Select again, please. 잘못된 입력을 하셨습니다..");
                    continue;
                }
            }
        }
    }
}
