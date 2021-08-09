using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse.AI;
using UnityEngine;

namespace RimPropaganda
{
    public class JobDriver_WatchPropaganda : JobDriver_WatchTelevision
    {
        protected override void WatchTickAction()
        {
            //pawn.ideo.Certainty

            //need to create comp
            CompPropaganda propaganda = ((Building)TargetA.Thing).TryGetComp<CompPropaganda>();
            if (propaganda != null)
            {
                float certChange = propaganda.certaintyFactor * ((Building)TargetA.Thing).GetStatValue(StatDefOf.JoyGainFactor, true);
                if (propaganda.ideo == pawn.ideo.Ideo)
                {
                    pawn.ideo.OffsetCertainty(certChange);
                }
                else
                {
                    pawn.ideo.IdeoConversionAttempt(certChange, propaganda.ideo);
                }
            }
            //pawn.ideo.

            base.WatchTickAction();
        }
    }
}
