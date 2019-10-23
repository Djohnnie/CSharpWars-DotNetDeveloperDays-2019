using System;
using System.Collections.Generic;
using System.Linq;
using CSharpWars.Enums;
using CSharpWars.Scripting;
using CSharpWars.Scripting.Model;
using CSharpWars.ScriptProcessor.Helpers;
using CSharpWars.ScriptProcessor.Middleware;

namespace CSharpWars.ScriptProcessor.Moves
{
    public class SelfDestruct : Move
    {
        public SelfDestruct(BotProperties botProperties) : base(botProperties)
        {
        }

        public override BotResult Go()
        {
            throw new NotImplementedException();
        }
    }
}