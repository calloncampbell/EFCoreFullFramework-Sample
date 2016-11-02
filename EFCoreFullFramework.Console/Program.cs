using System;
using System.Diagnostics;
using EFCoreFullFramework.Library.EFCore;

namespace EFCoreFullFramework.Console
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            System.Console.WriteLine("Running EF Core demo...");
            
            //First run will warm up database
            RunAddAndSaveChangesOptimized(0);

            RunAddAndSaveChangesOptimized(1);
            RunAddAndSaveChangesOptimized(2);
            RunAddAndSaveChangesOptimized(3);
            RunAddAndSaveChangesOptimized(4);

            System.Console.ReadLine();
        }

        private static void RunAddAndSaveChangesOptimized(int iteration)
        {
            sw.Restart();
            using (var db = new InventoryContext())
            {
                for (int i = 0; i < 1000; i++)
                {
                    db.Inventory.Add(new InventoryItem { Id = Guid.NewGuid(), Name = $"Item-{i}" });
                }
                db.SaveChanges();
            }
            sw.Stop();
            LogStopWatch(sw, iteration);
        }

        private static void LogStopWatch(Stopwatch sw, int iteration)
        {
            System.Console.WriteLine($" Iteration {iteration}");
            System.Console.WriteLine($"  - EF Core: {sw.ElapsedMilliseconds}ms");
        }
    }
}
