﻿using System;
using System.Linq;
using Verse;

namespace BloodTypes
{
    public class RecievedBloodTypeHediffWithComps : HediffWithComps
    {
        public BloodType BloodType;

        public override string LabelInBrackets => BloodType.ToString();

        public override void PostAdd(DamageInfo? dinfo)
        {
            pawn.RemoveHediff(RimWorld.HediffDefOf.BloodLoss);
            base.PostAdd(dinfo);
        }

        private short _index = 0;

        public override void PostTick()
        {
            
            _index %= 25791;
            if (_index == 0)
            {
                pawn.Clot();
            }
            _index++;
            base.PostTick();
        }
    }
}