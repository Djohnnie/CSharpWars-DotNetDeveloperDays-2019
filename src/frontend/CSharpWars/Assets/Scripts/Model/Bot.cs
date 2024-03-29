﻿using System;

namespace Assets.Scripts.Model
{
    public class Bot
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String PlayerName { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 FromX { get; set; }
        public Int32 FromY { get; set; }
        public PossibleOrientations Orientation { get; set; }
        public Int32 MaximumHealth { get; set; }
        public Int32 CurrentHealth { get; set; }
        public Int32 MaximumStamina { get; set; }
        public Int32 CurrentStamina { get; set; }
        public PossibleMoves Move { get; set; }
        public Int32 LastAttackX { get; set; }
        public Int32 LastAttackY { get; set; }
    }
}