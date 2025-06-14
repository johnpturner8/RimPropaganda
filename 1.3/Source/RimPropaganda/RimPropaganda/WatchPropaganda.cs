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
            CompPropaganda propaganda = ((Building)TargetA.Thing).TryGetComp<CompPropaganda>();
            if (propaganda != null && propaganda.showingPropaganda)
            {
                Job curJob = pawn.CurJob;
                float joyGain = curJob.def.joyGainRate;
                float certChange = propaganda.certaintyFactor * joyGain;
                if (propaganda.ideo == pawn.ideo.Ideo)
                {
                    //The only way to change certainty without throwing a mote
                    pawn.ideo.Debug_ReduceCertainty(-1 * certChange);
                }
                else
                {
                    pawn.ideo.Debug_ReduceCertainty(certChange * pawn.GetStatValue(StatDefOf.CertaintyLossFactor, true));
                    if(pawn.ideo.Certainty == 0)
                    {
                        pawn.ideo.SetIdeo(propaganda.ideo);
                        string text = "PropagandaConversion".Translate() + " " + propaganda.ideo;
                        MoteMaker.ThrowText(this.pawn.DrawPos, this.pawn.Map, text, 8f);
                    }
                    pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDef.Named("DislikedPropaganda"));
                }
            }
            base.WatchTickAction();
        }
    }

    public class JobDriver_ViewArtPropaganda : JobDriver_ViewArt
    {
        protected override void WaitTickAction()
        {
            CompPropaganda propaganda = ((Building)TargetA.Thing).TryGetComp<CompPropaganda>();
            if (propaganda != null && propaganda.ideo != null)
            {
                Thing art = this.job.GetTarget(TargetIndex.A).Thing;


                float num = art.GetStatValue(StatDefOf.Beauty, true) / art.def.GetStatValueAbstract(StatDefOf.Beauty, null);
                float extraJoyGainFactor = (num > 0f) ? num : 0f;
                Job curJob = pawn.CurJob;
                float joyGain = extraJoyGainFactor * curJob.def.joyGainRate;

                float certChange = propaganda.certaintyFactor * joyGain;
                if (propaganda.ideo == pawn.ideo.Ideo)
                {
                    //The only way to change certainty without throwing a mote
                    pawn.ideo.Debug_ReduceCertainty(-1 * certChange);
                }
                else
                {
                    pawn.ideo.Debug_ReduceCertainty(certChange * pawn.GetStatValue(StatDefOf.CertaintyLossFactor, true));
                    if (pawn.ideo.Certainty == 0)
                    {
                        pawn.ideo.SetIdeo(propaganda.ideo);
                        string text = "PropagandaConversion".Translate() + " " + propaganda.ideo;
                        MoteMaker.ThrowText(this.pawn.DrawPos, this.pawn.Map, text, 8f);
                    }

                    pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDef.Named("DislikedPropaganda"));
                }
            }
            base.WaitTickAction();
        }
    }
}
