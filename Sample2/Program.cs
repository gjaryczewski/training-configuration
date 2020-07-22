using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true) // true to flaga niewymagalnosci pliku, nie trzeba sprawdzac
                .AddEnvironmentVariables(prefix: "MyCustomPrefix_") // Tylko zmienne z tym prefiksem beda importowane
                .Build();

            // Konfiguracja moze miec postac zagniezdzona, tu zapisujemy pojedyncze wartosci z obiektu JSON
            var myKeyValue = configuration["ValueKey"];
            var title = configuration["Position:Title"];
            var name = configuration["Position:Name"];
            var defaultLogLevel = configuration["Logging:LogLevel:Default"];

            Console.WriteLine($"MyKey value: {myKeyValue} \n" +
                $"Title: {title} \n" +
                $"Name: {name} \n" +
                $"Default Log Level: {defaultLogLevel}");

            // Zmienna srodowiskowa miala w nazwie __, jest :
            Console.WriteLine(configuration["MyPosition:Title"]);
            Console.WriteLine(configuration["MyPosition:Name"]);

            // Domyslnie importowane sa zmienne ze srodowiska, ktore maja prefiks DOTNET_ lub ASPNETCORE_
        }
    }
}
