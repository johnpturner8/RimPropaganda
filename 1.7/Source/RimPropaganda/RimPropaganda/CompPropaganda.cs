using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
using Verse.AI;

namespace RimPropaganda
{
	[StaticConstructorOnStartup]
	class CompPropaganda : ThingComp
    {
		public bool showingPropaganda = false;

		public Ideo ideo;

		public float certaintyFactor => Props.certaintyFactor;
		public bool canChange => Props.canChange;

		public CompProperties_Propaganda Props
        {
            get
            {
                return (CompProperties_Propaganda)props;
            }
        }
		public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn selPawn)
		{
			if (canChange && selPawn.Ideo != null)
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
            else if (this.showingPropaganda && ideo != null)
            {
				message += "Showing propaganda for " + ideo.name + ".";
            }
			return message;
        }
		public override void PostPostMake()
        {
			if (Props.autoIdeo && ModsConfig.IdeologyActive)
			{
				ideo = Faction.OfPlayer?.ideos?.PrimaryIdeo;
				showingPropaganda = ideo != null;
			}
		}

	}

	class CompProperties_Propaganda : CompProperties
	{
		public bool canChange = true;
		public float certaintyFactor = 0f;
		public bool autoIdeo = false;

		public CompProperties_Propaganda()
		{
			this.compClass = typeof(CompPropaganda);
		}

	}
}
