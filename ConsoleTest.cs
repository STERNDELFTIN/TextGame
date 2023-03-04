using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ConsoleTest
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GameExec game = new GameExec();
                if (game.Process() == false) // 게임 종료
                    return;

                // 1. 마을 입장? 던전 입장?

                // 1-1. 마을 입장
                /// 가게, 훈련장, npc 호감도

                // 1-2. 던전 입장
                /// 앞으로 전진
                /// 확률적으로 몬스터와 조우하거나 아이템 획득할 수 있다거나 아무 일도 발생하지 않음
                /// 몬스터와 전투 시, 피가 0이하로 내려간다면 마을에서 부활 (일정 레벨 혹은 경험치 감소)
                /// 몬스터와의 전투 성공 시에는 일정 경험치 획득

                break;
            }
        }
    }
}
