using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sample1
{
    public class MySettingsConfig
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("record.json", true) // true to flaga niewymagalnosci pliku, nie trzeba sprawdzac
                .AddEnvironmentVariables()
                .Build();

            // Konfiguracja moze miec postac strukturyzowana, silnie typowana, oparta na tablicy wartosci lub z uzyciem wzorca Options
            var mySettingsConfig = configuration.Get<MySettingsConfig>();

            Console.WriteLine(mySettingsConfig);
            Console.WriteLine(mySettingsConfig.Name);
            Console.WriteLine(mySettingsConfig.Url);

            // Bind hierarchical configuration data using the options pattern
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#bind-hierarchical-configuration-data-using-the-options-pattern

            // Bind an array
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#bind-an-array
        }
    }
}
