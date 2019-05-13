using System;
using System.Reflection;

namespace DenisBaturin.AssemblyQuickInfo.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var aqi = new AssemblyQuickInfo(executingAssembly);

            Console.WriteLine("Information about the assembly using AssemblyQuickInfo:");
            Console.WriteLine("");

            Console.WriteLine($"Name: {aqi.Name}");
            Console.WriteLine($"Full name: {aqi.FullName}");
            Console.WriteLine($"Assembly version: {aqi.Version()}");
            Console.WriteLine($"Assembly version (3 fields): {aqi.Version(3)}");
            Console.WriteLine($"File version: {aqi.FileVersion}");
            Console.WriteLine($"Copyright: {aqi.Copyright}");
            Console.WriteLine($"Company: {aqi.Company}");
            Console.WriteLine($"Configuration: {aqi.Configuration}");
            Console.WriteLine($"Description: {aqi.Description}");
            Console.WriteLine($"Product: {aqi.Product}");
            Console.WriteLine($"Title: {aqi.Title}");
            Console.WriteLine($"Trademark: {aqi.Trademark}");
            Console.WriteLine($"GUID: {aqi.Guid}");
            Console.WriteLine($"Culture name: {aqi.CultureName}");
            Console.WriteLine($"COM-Visible: {aqi.ComVisible}");
            Console.WriteLine($"Code base: {aqi.CodeBase}");
            Console.WriteLine($"Location: {aqi.Location}");
            Console.WriteLine($"Directory name: {aqi.DirectoryName}");

            Console.WriteLine("");
            Console.Write("Press any key for exit...");
            Console.ReadKey();
        }
    }
}