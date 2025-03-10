using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // 1. 클래스와 상속
    class Warrior
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Strength { get; set; }
    }

    static void Main()
    {
        // 1. Warrior 객체 생성 및 출력
        Warrior warrior = new Warrior { Name = "Arthur", Score = 100, Strength = 80 };
        Console.WriteLine($"Name: {warrior.Name}, Score: {warrior.Score}, Strength: {warrior.Strength}");

        // 2. 예외 처리
        try
        {
            Console.Write("정수를 입력하세요: ");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine($"입력한 숫자: {userInput}");
        }
        catch (FormatException)
        {
            Console.WriteLine("올바른 숫자를 입력하세요!");
        }

        // 3. 컬렉션 활용
        List<string> fruits = new List<string> { "사과", "바나나", "포도" };
        Console.WriteLine("List 요소: " + string.Join(", ", fruits));

        Queue<string> tasks = new Queue<string>();
        tasks.Enqueue("첫 번째 작업");
        tasks.Enqueue("두 번째 작업");
        tasks.Enqueue("세 번째 작업");
        Console.WriteLine("Queue 요소: " + string.Join(", ", tasks));

        Stack<int> numbersStack = new Stack<int>();
        numbersStack.Push(10);
        numbersStack.Push(20);
        numbersStack.Push(30);
        while (numbersStack.Count > 0)
        {
            Console.WriteLine("Stack pop: " + numbersStack.Pop());
        }

        // 4. 문자열 처리
        Console.Write("문자열을 입력하세요: ");
        string inputStr = Console.ReadLine();
        string upperStr = inputStr.ToUpper();
        string replacedStr = upperStr.Replace("C#", "CSharp");
        Console.WriteLine($"대문자로 변환: {upperStr}");
        Console.WriteLine($"'C#'을 'CSharp'으로 변경: {replacedStr}");
        Console.WriteLine($"문자열 길이: {inputStr.Length}");

        // 5. LINQ 활용
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("짝수: " + string.Join(", ", evenNumbers));
        Console.WriteLine("모든 숫자의 합: " + numbers.Sum());
    }
}
