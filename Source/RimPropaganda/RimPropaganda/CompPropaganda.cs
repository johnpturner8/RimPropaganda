using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
using Verse.AI;
using RimPropoganda;

namespace RimPropaganda
{
	[StaticConstructorOnStartup]
	class CompPropaganda : ThingComp
    {
		public bool showingPropaganda = false;

		private Texture2D cachedCommandTex;

		public Ideo ideo;

		public float certaintyFactor => Props.certaintyFactor;
		public bool canChange => Props.canChange;
		//public bool beenInstalled => Props.beenInstalled;

		public CompProperties_Propaganda Props
        {
            get
            {
                return (CompProperties_Propaganda)props;
            }
        }
        //private Texture2D CommandTex
        //{
        //    get
        //    {
        //        if (this.cachedCommandTex == null)
        //        {
        //            this.cachedCommandTex = ContentFinder<Texture2D>.Get(this.Props.commandTexture, true);
        //        }
        //        return this.cachedCommandTex;
        //    }
        //}

		public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn selPawn)
		{
			if (canChange)
			{
				yield return new FloatMenuOption("SetIdeology".Translate(this.parent.Label) + selPawn.Ideo.name, delegate ()
				{
				selPawn.jobs.TryTakeOrderedJob(JobMaker.MakeJob(DefDatabase<JobDef>.GetNamed("SetPropagandaIdeology"), this.parent), new JobTag?(JobTag.Misc), false);
				}, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0);
				
				if (showingPropaganda)
				{
					yield return new FloatMenuOption("SetPropagandaOff".Translate(this.parent.Label), delegate ()
					{
					selPawn.jobs.TryTakeOrderedJob(JobMaker.MakeJob(DefDatabase<JobDef>.GetNamed("SetPropagandaOff"), this.parent), new JobTag?(JobTag.Misc), false);
					}, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0);
				}
			}
		}

        //public override IEnumerable<Gizmo> CompGetGizmosExtra()
        //{
        //    //if (!canChange && !beenInstalled)
        //        yield return new Designator_InstallPropaganda
        //        {
        //            defaultLabel = "InstallIdeo".Translate(),
        //            defaultDesc = "InstallIdeoDesc".Translate(),
        //            icon = CommandTex
        //        };
        //    yield break;
        //}

        //Saves power consumption settings
        public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_References.Look(ref ideo, "propIdeo");
			Scribe_Values.Look<bool>(ref showingPropaganda, "showingProp");
		}

		public override string CompInspectStringExtra()
        {
			string message = "";
			if(!canChange && ideo != null)
            {
				message += "Propaganda for " + ideo.name + ".";
			}
            else if (this.showingPropaganda)
            {
				message += "Showing propaganda for " + ideo.name + ".";
            }
			return message;
        }

		//public override IEnumerable<Gizmo> CompGetGizmosExtra()
		//{
		//	foreach (Gizmo gizmo in base.CompGetGizmosExtra())
		//	{
		//		yield return gizmo;
		//	}
		//	IEnumerator<Gizmo> enumerator = null;
		//	if (this.parent.Faction == Faction.OfPlayer)
		//	{
		//		yield return new Command_Toggle
		//		{
		//			icon = this.CommandTex,
		//			defaultLabel = this.Props.commandLabelKey.Translate(),
		//			defaultDesc = this.Props.commandDescKey.Translate(),
		//			isActive = (() => this.showingPropoganda),
		//			toggleAction = delegate ()
		//			{
		//				this.showingPropoganda = !this.showingPropoganda;
		//			}
		//		};
		//	}
		//	yield break;
		//}
		public override void PostPostMake()
        {
			if (Props.autoIdeo)
			{
				showingPropaganda = true;
				ideo = Faction.OfPlayer.ideos.PrimaryIdeo;
			}
			Log.Message("PostPostMake CompPropaganda");
		}

	}

	class CompProperties_Propaganda : CompProperties
	{
		public bool canChange = true;
		//public bool beenInstalled = false;
		public float certaintyFactor;
		//public bool installAsPropaganda = true;
		public bool autoIdeo = false;

		public string commandTexture = "InstallIdeo";
		//public string commandLabelKey = "CommandDesignateTogglePowerLabel";
		//public string commandDescKey = "CommandDesignateTogglePowerDesc";

		public CompProperties_Propaganda()
		{
			this.compClass = typeof(CompPropaganda);
		}

	}
}
