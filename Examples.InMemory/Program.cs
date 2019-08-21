using System;
using System.Linq;

namespace Examples.InMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Commands.Setup();

            var r = new Service(new InMemoryDB()).Get();
            foreach (var item in r)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Finished");
            Console.Read();
        }
    }
}
