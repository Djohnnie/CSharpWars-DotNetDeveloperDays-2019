using System;
using CSharpWars.Common.Extensions;
using CSharpWars.Enums;
using CSharpWars.Scripting.Model;

namespace CSharpWars.Scripting
{
    public class ScriptGlobals
    {
        #region <| Private Members |>

        private readonly BotProperties _50437079C366407D978Fe4Afd60C535F;
        private readonly Vision _vision;

        #endregion

        #region <| Public Properties |>

        

        #endregion

        #region <| Constants |>

        

        #endregion

        #region <| Construction |>

        private ScriptGlobals(BotProperties botProperties)
        {
            _50437079C366407D978Fe4Afd60C535F = botProperties;
            _vision = Vision.Build(botProperties);
        }

        public static ScriptGlobals Build(BotProperties botProperties)
        {
            return new ScriptGlobals(botProperties);
        }

        #endregion

        #region <| Public Methods |>

        

        #endregion

        #region <| Helper Methods |>

        private Boolean SetCurrentMove(PossibleMoves currentMove)
        {
            if (_50437079C366407D978Fe4Afd60C535F.CurrentMove == PossibleMoves.Idling)
            {
                _50437079C366407D978Fe4Afd60C535F.CurrentMove = currentMove;
                return true;
            }

            return false;
        }

        private void SetCurrentMove(PossibleMoves currentMove, Int32 x, Int32 y)
        {
            if (SetCurrentMove(currentMove))
            {
                _50437079C366407D978Fe4Afd60C535F.MoveDestinationX = x;
                _50437079C366407D978Fe4Afd60C535F.MoveDestinationY = y;
            }
        }

        #endregion
    }
}