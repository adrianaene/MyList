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
            MyList<int> numbers = new MyList<int>(3);
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(6);
            Console.WriteLine("Size: " + numbers.Size);
            numbers.Add(7);
            numbers.Add(12);
            numbers.Add(3);
            numbers.Add(20);
            Console.WriteLine("Size: " + numbers.Size);
            numbers[4] = 10;

            Func<int, bool> even_Function = delegate(int number)
            {
                return number % 2 == 0;
            };

            Console.WriteLine("Print even numbers: ");

            MyList<int> evenNumbers = numbers.FindAll(even_Function);
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write(evenNumber + " ");
            }

            numbers.RemoveAt(1);
            numbers.RemoveAt(2);           

            Console.WriteLine("\nPrint with enumerator:");
            var enumerator = numbers.GetEnumerator();
            foreach(int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\nPrint with indexer:");
            for (int i = 0; i < numbers.Count; i++)
                Console.Write(numbers[i] + " ");
            
            Console.WriteLine( "\n" + numbers.Contains(10));
            numbers.Clear();
            Console.WriteLine(numbers.Count);            
            Console.Read();
        }
    }
}
