﻿using System;
using CSharpWars.Enums;
using CSharpWars.Scripting.Model;
using CSharpWars.ScriptProcessor.Helpers;
using CSharpWars.ScriptProcessor.Middleware;

namespace CSharpWars.ScriptProcessor.Moves
{
    /// <summary>
    /// Class containing logic for turning around.
    /// </summary>
    /// <remarks>
    /// Performing this move makes the robot turn 180°.
    /// This move does not consume stamina because the robot will not move away from its current location in the arena grid.
    /// </remarks>
    public class TurnAround : Move
    {
        public TurnAround(BotProperties botProperties) : base(botProperties) { }

        public override BotResult Go()
        {
            throw new NotImplementedException();
        }
    }
}