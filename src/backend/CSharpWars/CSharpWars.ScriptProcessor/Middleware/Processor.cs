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
            throw new NotImplementedException();
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