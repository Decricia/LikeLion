using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Study6
{
    class Program
    {
        static void Main(string[] args)
        {
            //문제 1번
            Console.Write("세개의 정수를 입력해주세요 : ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a > b && a > c)
            {
                int temp = a;
                Console.WriteLine($"가장 큰 수는 {a}입니다.");
            }
            else if (b > a && b > c)
            {
                int temp = b;
                Console.WriteLine($"가장 큰 수는 {b}입니다.");
            }
            else if (c > a && c > a)
            {
                int temp = c;
                Console.WriteLine($"가장 큰 수는 {c}입니다.");
            }

            Console.WriteLine("");

            //문제 2번
            Console.Write("점수를 입력해주세요 : ");
            int score = int.Parse(Console.ReadLine());

            if (score < 60)
            {
                Console.WriteLine("F 학점");
            }
            else if (score >= 60 && score < 70)
            {
                Console.WriteLine("D 학점");
            }
            else if (score >= 70 && score < 80)
            {
                Console.WriteLine("C 학점");
            }
            else if (score >= 80 && score < 90)
            {
                Console.WriteLine("B 학점");
            }
            else
            {
                Console.WriteLine("A 학점");
            }

            Console.WriteLine("");
            Console.Write("첫 번째 숫자를 입력해주세요: ");
            int n1 = int.Parse(Console.ReadLine());

            Console.Write("두 번째 숫자를 입력해주세요: ");
            int n2 = int.Parse(Console.ReadLine());

            Console.Write("연산자 기호를 입력해주세요 (+, -, *, /): ");
            string oper = Console.ReadLine();

            if (oper == "+")
            {
                int sum = n1 + n2;
                Console.WriteLine($"두 수의 합은 {sum}");
            }
            else if (oper == "-")
            {
                int sub = n1 - n2;
                Console.WriteLine($"두 수의 뺄셈은 {sub}");
            }
            else if (oper == "*")
            {
                int mul = n1 * n2;
                Console.WriteLine($"두 수의 곱셈은 {mul}");
            }
            else if (oper == "/")
            {
                if (n2 == 0) // 나누는 수(n2)가 0이면 오류 메시지 출력 후 종료
                {
                    Console.WriteLine("0으로 나눌 수 없습니다. 결과 X");
                }
                else
                {
                    int div = n1 / n2;
                    Console.WriteLine($"두 수의 나눗셈은 {div}");
                }
            }
            else
            {
                Console.WriteLine("올바른 연산자가 아닙니다.");
            }

        }
    }
}
