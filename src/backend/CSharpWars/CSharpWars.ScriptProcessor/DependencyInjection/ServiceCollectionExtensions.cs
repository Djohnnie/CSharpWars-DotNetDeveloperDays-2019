using CSharpWars.Common.DependencyInjection;
using CSharpWars.Logic.DependencyInjection;
using CSharpWars.ScriptProcessor.Middleware;
using CSharpWars.ScriptProcessor.Middleware.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpWars.ScriptProcessor.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureScriptProcessor(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureCommon();
            serviceCollection.ConfigureLogic();
            serviceCollection.AddScoped<IMiddleware, Middleware.Middleware>();
            serviceCollection.AddScoped<IPreprocessor, Preprocessor>();
            serviceCollection.AddSingleton<IProcessor, Processor>();
            serviceCollection.AddScoped<IPostprocessor, Postprocessor>();
        }
    }
}