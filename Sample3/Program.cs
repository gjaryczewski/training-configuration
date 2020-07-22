using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Sample3
{
    class Program
    {
        static void Main(string[] args)
        {
            var switchMappings = new Dictionary<string, string>()
            {
                { "-k1", "key1" },
                { "-k2", "key2" },
                { "--alt3", "key3" },
                { "--alt4", "key4" },
                { "--alt5", "key5" },
                { "--alt6", "key6" },
            };

            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args, switchMappings)
                .Build();

            Console.WriteLine($"Key1: '{configuration["key1"]}'\n" +
                $"Key2: '{configuration["key2"]}'\n" +
                $"Key3: '{configuration["key3"]}'\n" +
                $"Key4: '{configuration["key4"]}'\n" +
                $"Key5: '{configuration["key5"]}'\n" +
                $"Key6: '{configuration["key6"]}'");
        }
    }
}
