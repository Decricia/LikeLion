using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion
{
    class Program
    {
        static void Main(string[] args)
        {

            float ruinDamage = 0.0f;
            float cardGauge = 0.0f;
            float ultDamage = 0.0f;
            float maxMP = 0.0f;
            float recoveryMP = 0.0f;
            float idleRecoveryMP = 0.0f;
            float moveSpeed = 0.0f;
            float rideSpeed = 0.0f;
            float transSpeed = 0.0f;
            float coolDown = 0.0f;

            Console.Write("루인 스킬 피해를 입력해주세요. : ");
            ruinDamage = float.Parse(Console.ReadLine());

            Console.Write("카드 게이지 획득량을 입력하세요 : ");
            cardGauge = float.Parse(Console.ReadLine());

            Console.Write("각성기 피해를 입력하세요. : ");
            ultDamage = float.Parse(Console.ReadLine());

            Console.Write("최대 마나를 입력하세요. : ");
            maxMP = float.Parse(Console.ReadLine());

            Console.Write("전투 중 마나 회복량을 입력하세요. : ");
            recoveryMP = float.Parse(Console.ReadLine());

            Console.Write("비 전투 중 마나 회복량을 입력하세요. : ");
            idleRecoveryMP = float.Parse(Console.ReadLine());

            Console.Write("이동속도를 입력하세요. : ");
            moveSpeed = float.Parse(Console.ReadLine());

            Console.Write("탈 것 속도를 입력하세요. : ");
            rideSpeed = float.Parse(Console.ReadLine());

            Console.Write("운반속도를 입력하세요. : ");
            transSpeed = float.Parse(Console.ReadLine());

            Console.Write("스킬 재사용 대기시간을 입력하세요. : ");
            coolDown = float.Parse(Console.ReadLine());

            Console.WriteLine("------------------------------------------");

            Console.WriteLine($"루인 스킬 피해 :    {ruinDamage}%");
            Console.WriteLine($"카드 게이지 획득량 :    {cardGauge}%");
            Console.WriteLine($"각성기 피해 :    {ultDamage}%");
            Console.WriteLine($"최대 마나 :    {maxMP}");
            Console.WriteLine($"전투 중 마나 회복량 :    {recoveryMP}");
            Console.WriteLine($"비 전투 중 마나 회복량 :    {idleRecoveryMP}");
            Console.WriteLine($"이동속도 :    {moveSpeed}%");
            Console.WriteLine($"탈 것 속도 :    {rideSpeed}%");
            Console.WriteLine($"운반속도 :    {transSpeed}%");
            Console.WriteLine($"스킬 재사용 대기시간 감소 :    {coolDown}%");
        }
    }
}
