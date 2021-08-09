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
    class CompPropaganda : ThingComp
    {
		public bool showingPropoganda
        {
            get
            {
				return Props.showingPropoganda;
            }
            set
            {
				Props.showingPropoganda = value;
            }
        }

		private Texture2D cachedCommandTex;

		public Ideo ideo;

		public float certaintyFactor => Props.certaintyFactor;

		private CompProperties_Propaganda Props
        {
            get
            {
                return (CompProperties_Propaganda)props;
            }
        }
        private Texture2D CommandTex
        {
            get
            {
                if (this.cachedCommandTex == null)
                {
                    this.cachedCommandTex = ContentFinder<Texture2D>.Get(this.Props.commandTexture, true);
                }
                return this.cachedCommandTex;
            }
        }

		public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn selPawn)
        {
			yield return new FloatMenuOption("SetIdeology".Translate(this.parent.Label), delegate ()
			{
				//TODO make JobDef
				selPawn.jobs.TryTakeOrderedJob(JobMaker.MakeJob(DefDatabase<JobDef>.GetNamed("SetPropogandaIdeology"), this.parent), new JobTag?(JobTag.Misc), false);
					//FloatMenuMakerMap.PawnGotoAction(this.parent.Position, CompHackable.tmpAllowedPawns[l], RCellFinder.BestOrderedGotoDestNear(this.parent.Position, CompHackable.tmpAllowedPawns[l], null));
			}, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0);
			//if ()
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
	}

	class CompProperties_Propaganda : CompProperties
	{
		public bool showingPropoganda = false;
		public float certaintyFactor;

		public string commandTexture = "UI/Commands/DesirePower";
		public string commandLabelKey = "CommandDesignateTogglePowerLabel";
		public string commandDescKey = "CommandDesignateTogglePowerDesc";

		public CompProperties_Propaganda()
		{
			this.compClass = typeof(CompPropaganda);
		}

	}
}
