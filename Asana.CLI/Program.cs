using System;
using Asana.Library.Models;

namespace Asana
{
    public class Program
    {
        static void Main(string[] args)
        {
            ToDo first = new ToDo();

            Console.WriteLine(first.Name?.Length > 0 ? first.Name : "No name provided");
        }
    }
}