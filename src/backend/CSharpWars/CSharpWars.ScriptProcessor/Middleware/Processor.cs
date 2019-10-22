using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSharpWars.Common.Extensions;
using CSharpWars.DtoModel;
using CSharpWars.Enums;
using CSharpWars.Logic.Interfaces;
using CSharpWars.Scripting;
using CSharpWars.Scripting.Model;
using CSharpWars.ScriptProcessor.Helpers;
using CSharpWars.ScriptProcessor.Middleware.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace CSharpWars.ScriptProcessor.Middleware
{
    public class Processor : IProcessor
    {
        private readonly ConcurrentDictionary<Guid, Script> _scriptCache = new ConcurrentDictionary<Guid, Script>();

        private readonly IBotLogic _botLogic;

        public Processor(IBotLogic botLogic)
        {
            _botLogic = botLogic;
        }

        public async Task Go(ProcessingContext context)
        {
            var botProcessing = context.Bots.Select(bot => Process(bot, context));
            await Task.WhenAll(botProcessing);
        }

        public async Task Process(BotDto bot, ProcessingContext context)
        {
            var botProperties = context.GetBotProperties(bot.Id);
            try
            {
                var botScript = await GetCompiledBotScript(bot);
                var scriptGlobals = ScriptGlobals.Build(botProperties);
                await botScript.RunAsync(scriptGlobals);
            }
            catch
            {
                botProperties.CurrentMove = PossibleMoves.ScriptError;
            }
        }

        private async Task<Script> GetCompiledBotScript(BotDto bot)
        {
            if (!ScriptStored(bot.Id))
            {
                try
                {
                    var script = await _botLogic.GetBotScript(bot.Id);
                    var botScript = Compile(script);
                    StoreScript(bot.Id, botScript);
                }
                catch (Exception ex)
                {
                    //
                }
            }

            return LoadScript(bot.Id);
        }

        public Script Compile(String script)
        {
            var decodedScript = script.Base64Decode();
            var mscorlib = typeof(Object).Assembly;
            var systemCore = typeof(Enumerable).Assembly;
            var dynamic = typeof(DynamicAttribute).Assembly;
            var csharpScript = typeof(BotProperties).Assembly;
            var enums = typeof(PossibleMoves).Assembly;
            var scriptOptions = ScriptOptions.Default.AddReferences(mscorlib, systemCore, dynamic, csharpScript, enums);
            scriptOptions = scriptOptions.WithImports("System", "System.Linq", "System.Collections", "System.Collections.Generic", "CSharpWars.Enums", "CSharpWars.Scripting", "CSharpWars.Scripting.Model", "System.Runtime.CompilerServices");
            var botScript = CSharpScript.Create(decodedScript, scriptOptions, typeof(ScriptGlobals));
            botScript.WithOptions(botScript.Options.AddReferences(mscorlib, systemCore));
            botScript.Compile();
            return botScript;
        }

        public Boolean ScriptStored(Guid botId)
        {
            return _scriptCache.ContainsKey(botId);
        }

        public void StoreScript(Guid botId, Script script)
        {
            _scriptCache.AddOrUpdate(botId, script, (a, b) => script);
        }

        public Script LoadScript(Guid botId)
        {
            if (ScriptStored(botId))
            {
                return _scriptCache[botId];
            }
            throw new ArgumentException("No cached script for bot was found.", nameof(botId));
        }
    }
}