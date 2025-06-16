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
        protected override void WatchTickAction(int delta)
        {
            CompPropaganda propaganda = ((Building)TargetA.Thing).TryGetComp<CompPropaganda>();
            if (propaganda != null && propaganda.showingPropaganda)
            {
                
                Job curJob = this.pawn.CurJob;
                float joyGain = curJob.def.joyGainRate;
                float scale = LoadedModManager.GetMod<PropagandaMod>().GetSettings<PropagandaSettings>().tvPropScale;

                float certChange = propaganda.certaintyFactor * joyGain * delta * scale;
                if (propaganda.ideo == this.pawn.ideo.Ideo)
                {
                    //The only way to change certainty without throwing a mote
                    this.pawn.ideo.Debug_ReduceCertainty(-1 * certChange);
                }
                else
                {
                    this.pawn.ideo.Debug_ReduceCertainty(certChange * this.pawn.GetStatValue(StatDefOf.CertaintyLossFactor, true));
                    if(this.pawn.ideo.Certainty == 0)
                    {
                        this.pawn.ideo.SetIdeo(propaganda.ideo);
                        string text = "PropagandaConversion".Translate() + " " + propaganda.ideo;
                        MoteMaker.ThrowText(this.pawn.DrawPos, this.pawn.Map, text, 8f);
                    }
                    this.pawn.needs.mood.thoughts.memories.TryGainMemoryFast(ThoughtDef.Named("DislikedPropaganda"));
                }
            }
            base.WatchTickAction(delta);
        }
    }

    public class JobDriver_ViewArtPropaganda : JobDriver_ViewArt
    {
        protected override void WaitTickAction(int delta)
        {
            CompPropaganda propaganda = ((Building)TargetA.Thing).TryGetComp<CompPropaganda>();
            if (propaganda != null && propaganda.ideo != null)
            {
                Thing art = this.job.GetTarget(TargetIndex.A).Thing;

                float num = art.GetStatValue(StatDefOf.Beauty, true) / art.def.GetStatValueAbstract(StatDefOf.Beauty, null);
                float extraJoyGainFactor = (num > 0f) ? num : 0f;
                Job curJob = this.pawn.CurJob;
                float joyGain = extraJoyGainFactor * curJob.def.joyGainRate;
                float scale = LoadedModManager.GetMod<PropagandaMod>().GetSettings<PropagandaSettings>().artPropScale;

                float certChange = propaganda.certaintyFactor * joyGain * delta * scale;
                if (propaganda.ideo == this.pawn.ideo.Ideo)
                {
                    //The only way to change certainty without throwing a mote
                    this.pawn.ideo.Debug_ReduceCertainty(-1 * certChange);
                }
                else
                {
                    this.pawn.ideo.Debug_ReduceCertainty(certChange * this.pawn.GetStatValue(StatDefOf.CertaintyLossFactor, true));
                    if (this.pawn.ideo.Certainty == 0)
                    {
                        this.pawn.ideo.SetIdeo(propaganda.ideo);
                        string text = "PropagandaConversion".Translate() + " " + propaganda.ideo;
                        MoteMaker.ThrowText(this.pawn.DrawPos, this.pawn.Map, text, 8f);
                    }

                    this.pawn.needs.mood.thoughts.memories.TryGainMemoryFast(ThoughtDef.Named("DislikedPropaganda"));
                }
            }
            base.WaitTickAction(delta);
        }
    }
}
