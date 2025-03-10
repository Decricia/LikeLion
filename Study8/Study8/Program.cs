using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Study8
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  //Q1
              int[] num = new int[5] { 10, 20, 30, 40, 50 };
              for(int n =0; n<5; n++)
              {
                  int output = num[n];
                  Console.Write($" {output}");
              }*/

            /*   //Q2
               int[] array2 = new int[5];
               int sum = 0;

               Console.Write("숫자입력 : ");


               for( int index = 0; index < 5; index++)
               {
                   array2[index] = int.Parse(Console.ReadLine());
                   sum += array2[index];
               }

               Console.WriteLine($"총 합 : {sum}");*/

            //Q3
            Console.WriteLine("{3, 8, 15, 6, 2} 중에서 가장 큰 값을 찾아보세요");
            int[] array3 = new int[5] { 3, 8, 15, 6, 2 };
            int max = 0;
            for(int i = 0;  i<5; i++)
            {
                if(max < array3[i])
                {
                    max = array3[i];
                }
            }
            Console.WriteLine(max);
        }
    }
}
