using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using Verse.AI;
using RimPropaganda;
using UnityEngine;

namespace RimPropoganda
{
    //[StaticConstructorOnStartup]
    //static class Propaganda_Patches
    //{
    //    static Propaganda_Patches()
    //    {
    //        var harmony = new Harmony("Propaganda");

    //        //var mOriginal = AccessTools.Method("JobDriver_ConstructFinishFrame:MakeNewToils");
    //        var mOriginal = AccessTools.Method("Dialog_BillConfig:DoWindowContents");
    //        //var mPostfix = typeof(Propaganda_Patches).GetMethod("ConstructInstallPostfix");
    //        var mPostfix = typeof(Propaganda_Patches).GetMethod("BillConfigPostfix");

    //        if (mOriginal != null)
    //        {
    //            //applies patch
    //            var propPatch = new HarmonyMethod(mPostfix);
    //            harmony.Patch(mOriginal, postfix: propPatch);
    //        }
    //    }

    //    //[HarmonyPostfix]
    //    //public static void BillConfigPostfix(ref Bill_Production bill, ref Rect inRect)
    //    //{
    //    //    Listing_Standard listing_Standard7 = new Listing_Standard();
    //    //    float width = (float)((int)((inRect.width - 34f) / 3f));
    //    //    Rect rect2 = new Rect(0f, 500f, width, inRect.height - 80f);
            

    //    //    ThingDef producedThingDef = bill.recipe.ProducedThingDef;
    //    //    if (producedThingDef.IsArt)
    //    //    {
    //    //        if (producedThingDef.HasComp(Type.GetType("CompPropaganda")))
    //    //        {
    //    //            listing_Standard7.Begin(rect2);

    //    //            //if (producedThingDef.GetCompProperties)
    //    //            //{
    //    //            //    if (listing_Standard7.ButtonText("Suspended".Translate(), null))
    //    //            //    {
    //    //            //        bill.suspended = false;
    //    //            //        SoundDefOf.Click.PlayOneShotOnCamera(null);
    //    //            //    }
    //    //            //}
    //    //            //else if (listing_Standard6.ButtonText("NotSuspended".Translate(), null))
    //    //            //{
    //    //            //    this.bill.suspended = true;
    //    //            //    SoundDefOf.Click.PlayOneShotOnCamera(null);
    //    //            //}

    //    //            //IEnumerable<Widgets.DropdownMenuElement<Ideo>> GeneratePropagandaOptions()
    //    //            //{
    //    //            //    yield return new Widgets.DropdownMenuElement<Ideo>
    //    //            //    {
    //    //            //        option = new FloatMenuOption("AnyWorker".Translate(), delegate ()
    //    //            //        {
    //    //            //            this.bill.SetAnyPawnRestriction();
    //    //            //        }, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0),
    //    //            //        payload = null
    //    //            //    };
    //    //            //}

    //    //            //Widgets.Dropdown<Bill_Production, Ideo>(listing_Standard7.GetRect(30f), bill, (Bill_Production b) => b.PawnRestriction, (Bill_Production b) => GeneratePropagandaOptions, "Propaganda Ideology", null, null, null, null, false);

    //    //            listing_Standard7.ButtonText("Not Propaganda", null);
    //    //            //list
    //    //            //Find.WindowStack.Add(new FloatMenu());
    //    //            listing_Standard7.End();
    //    //        }
    //    //    }
    //    //}

        

    //        /*[HarmonyPostfix]
    //        public static void ConstructInstallPostfix(ref Toil __result, ref JobDriver_ConstructFinishFrame __instance)
    //        {
    //            Thing b = __instance.job.GetTarget(TargetIndex.A).Thing;
    //            CompArt compArt = b.TryGetComp<CompArt>();
    //            //checks if an art piece which has never been installed
    //            if (compArt != null)
    //            {
    //                CompPropaganda compProp = b.TryGetComp<CompPropaganda>();
    //                if(compProp != null && compProp.beenInstalled == false)
    //                {
    //                    Pawn p = __instance.pawn;
    //                    Action setArtProp = delegate
    //                    {
    //                        if (compProp.beenInstalled == false) { 
    //                            compProp.Props.beenInstalled = true;
    //                            //compProp.ideo = p.Ideo;
    //                            compProp.ideo = Faction.OfPlayer.ideos.PrimaryIdeo;
    //                        }
    //                    };
    //                    __instance.AddFinishAction(setArtProp);
    //                }
    //            }             
    //        }*/
    //    }
}
