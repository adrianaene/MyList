using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> numbers = new MyList<int>(10);
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(6);
            numbers.Add(7);
            numbers[4] = 9;

            Func<int, bool> even_Function = delegate(int number)
            {
                return number % 2 == 0;
            };

            MyList<int> evenNumbers = numbers.FindAll(even_Function);
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }

            numbers.RemoveAt(1);
            numbers.RemoveAt(2);           

            Console.WriteLine("\nPrint with enumerator:");
            var enumerator = numbers.GetEnumerator();
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("\nPrint with indexer:");
            for (int i = 0; i < numbers.Count; i++)
                Console.WriteLine(numbers[i]);
            
            Console.WriteLine(numbers.Contains(10));
            numbers.Clear();
            Console.WriteLine(numbers.Count);
            
            Console.Read();
        }
    }
}
