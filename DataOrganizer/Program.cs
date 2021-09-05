using DataOrganizer.Sources;
using System;

namespace DataOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SourceService sourceService = new SourceService();
            Console.WriteLine($"sources loaded. {sourceService.ServiceCount}, {sourceService.FolderCount}, {sourceService.FileCount}");
            Console.ReadLine();

        }
    }
}
