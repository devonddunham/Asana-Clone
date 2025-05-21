using System;
using Asana.Library.Models;

namespace Asana
{
    public class Program
    {
        static void Main(string[] args)
        {
            var todos = new List<ToDo>();
            var choiceInt = 0;

            do
            {
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. Exit");

                Console.WriteLine("Enter your choice:");
                // if ReadLine is null, set choiceInt to 2
                var choice = Console.ReadLine() ?? "2";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1:
                            var todo = new ToDo();
                            Console.WriteLine("Name:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Description:");
                            var descrip = Console.ReadLine();
                            todos.Add(new ToDo { Name = name, Description = descrip, });
                            break;
                        case 2:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("*** ERROR: Invalid choice ***");
                            break;
                    }
                }
                else
                    Console.WriteLine($"*** ERROR: Invalid choice: {choice} ***");

                if(todos.Any())
                    Console.WriteLine(todos.Last());
            } while (choiceInt != 2);
        }
    }
}