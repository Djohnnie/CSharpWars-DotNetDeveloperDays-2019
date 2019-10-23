using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CSharpWars.Common.DependencyInjection;
using CSharpWars.ScriptProcessor.DependencyInjection;
using CSharpWars.ScriptProcessor.Middleware.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
using static System.Convert;
using static System.Environment;

namespace CSharpWars.ScriptProcessor
{

    [ExcludeFromCodeCoverage]
    class Program
    {
        private const Int32 DELAY_MS = 2000;

        static void Main(string[] args)
        {
            WriteLine("CSharp Wars Processing Console");
            WriteLine("------------------------------");
            WriteLine();

            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            throw new NotImplementedException();
        }
    }
}