using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using Unity;
using Verse.AI;

namespace RimPropaganda
{
    class JobDriver_SetPropagandaIdeology : JobDriver
    {
        private Thing Broadcaster
        {
            get
            {
                return base.TargetThingA;
            }
        }

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return this.pawn.Reserve(this.Broadcaster, this.job, 1, -1, null, errorOnFailed);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            Toil toil = new Toil();
            toil.initAction = () =>
            {
                Broadcaster.TryGetComp<CompPropaganda>().ideo = pawn.ideo.Ideo;
                Broadcaster.TryGetComp<CompPropaganda>().showingPropoganda = true;
            };
            yield return toil;
            yield break;
        }
    }
    
    class JobDriver_SetPropogandaOff
    {

    }

    class WorkGiver_SetPropogandaIdeology : WorkGiver_Scanner
    {
        public override Job JobOnThing(Pawn pawn, Thing t, bool forced)
        {
            Job job = new Job(DefDatabase<JobDef>.GetNamed("SetPropogandaIdeology"), t);
            return job;
        }
    }
}
