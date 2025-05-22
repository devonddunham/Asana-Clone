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
                Console.WriteLine("1. Add a new ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDo's");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Enter your choice:");
                // if ReadLine is null, set choiceInt to 2
                var choice = Console.ReadLine() ?? "10";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1:
                            Console.WriteLine("Name:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Description:");
                            var descrip = Console.ReadLine();
                            Console.WriteLine("Priority:");
                            // assign a priority 1-5
                            var priority = Console.ReadLine();
                            if (int.TryParse(priority, out var priorityInt))
                            {
                                if (priorityInt < 1 || priorityInt > 5)
                                    Console.WriteLine($"*** ERROR: Invalid priority: {priority} ***");
                            }
                            else
                                Console.WriteLine($"*** ERROR: Invalid priority: {priority} ***");
        
                            var id = todos.Count + 1;
                            todos.Add(new ToDo { Id = id, Name = name, Description = descrip, Priority = priorityInt, IsComplete = false });
                            break;
                        case 2:
                            PrintToDos(todos);
                            Console.WriteLine("Enter the ID of the ToDo to delete:");
                            var deleteId = Console.ReadLine();
                            if (int.TryParse(deleteId, out var idToDelete))
                            {
                                if (idToDelete > 0 && idToDelete <= todos.Count + 1)
                                {
                                    todos.Remove(todos[idToDelete - 1]);
                                    Console.WriteLine($"Deleted ToDo with ID {idToDelete}");
                                    for (int i = idToDelete - 1; i < todos.Count; i++)
                                        todos[i].Id = i + 1;
                                }
                                else
                                    Console.WriteLine($"No ToDo found with ID {idToDelete}");
                            }
                            else
                                Console.WriteLine($"*** ERROR: Invalid ID: {deleteId} ***");
                            break;
                        case 3:
                            PrintToDos(todos);
                            Console.WriteLine("Enter the ID of the ToDo to update:");
                            var updateId = Console.ReadLine();
                            if (int.TryParse(updateId, out var idToUpdate))
                            {
                                if (idToUpdate > 0 && idToUpdate <= todos.Count + 1)
                                {
                                    Console.WriteLine("Name:");
                                    var updateName = Console.ReadLine();
                                    Console.WriteLine("Description:");
                                    var updateDescrip = Console.ReadLine();
                                    Console.WriteLine("Priority:");
                                    var updatePriority = Console.ReadLine();
                                    if (int.TryParse(updatePriority, out var updatePriorityInt))
                                    {
                                        if (updatePriorityInt < 1 || updatePriorityInt > 5)
                                            Console.WriteLine($"*** ERROR: Invalid priority: {updatePriority} ***");
                                    }
                                    else
                                        Console.WriteLine($"*** ERROR: Invalid priority: {updatePriority} ***");
        
                                    todos[idToUpdate - 1].Name = updateName;
                                    todos[idToUpdate - 1].Description = updateDescrip;
                                    todos[idToUpdate - 1].Priority = updatePriorityInt;
                                }
                                else
                                    Console.WriteLine($"No ToDo found with ID {idToUpdate}");
                            }
                            else
                                Console.WriteLine($"*** ERROR: Invalid ID: {updateId} ***");
                            break;
                        case 4:
                            if (!todos.Any())
                                Console.WriteLine("No ToDo's found.");
                            else
                            {
                                Console.WriteLine("ToDo's:");
                                PrintToDos(todos);
                            }
                            break;
                        case 10:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("*** ERROR: Invalid choice ***");
                            break;
                    }
                }
                else
                    Console.WriteLine($"*** ERROR: Invalid choice: {choice} ***");

                if (todos.Any())
                    Console.WriteLine(todos.Last());
            } while (choiceInt != 10);
        }
        
        public static void PrintToDos(List<ToDo> todos)
        {
            foreach (var todo in todos)
                Console.WriteLine(todo);
        }
    }
}