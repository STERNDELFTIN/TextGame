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
        string id;
        public Dungeon(Dictionary<string, Player> player, string id)
        {
            this.id = id;
            Battle(player, id);
        }

        public static void CreateMonster()
        {
            Monster mon = null;
            Random rand = new Random();
            int randMon = rand.Next(1, 3);
            string monName = Enum.GetName(typeof(StatType), randMon);

            switch (randMon)
            {
                case (int)MonsterType.Rabbit:
                    mon = new Rabbit();
                    break;
                case (int)MonsterType.Wolf:
                    mon = new Wolf();
                    break;
                case (int)MonsterType.Slime:
                    mon = new Slime();
                    break;
                default:
                    break;
            }
            mon.Info();
        }

        public void Battle(Dictionary<string, Player> player, string id)
        {
            
            while (true)
            {
                //monster[id].HP -= player[id].STR;
            }
        }
    }
}
