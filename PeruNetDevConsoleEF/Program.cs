using System;
using PeruNetDev.DataLayer;
using PeruNetDev.Entities;

namespace PeruNetDevConsoleEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework Core 5.0!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Peru NET Development";

            using (var ctx = new PeruNetDevDbContext())
            {
                var person = new Person
                {
                    Name = "Erick", 
                    LastName = "Orlando",
                    Age =  36,
                    Email = "evelasco@perunetdev.org"
                };

                ctx.Persons.Add(person); // INSERT.
                ctx.SaveChanges();


                foreach (var entity in ctx.Persons)
                {
                    Console.WriteLine($"Person: {entity.Name}");
                }

            }

            Console.ReadLine();
        }
    }
}
