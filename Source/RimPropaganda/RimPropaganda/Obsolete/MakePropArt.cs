using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimPropoganda
{
    [StaticConstructorOnStartup]
    static class MakePropArt
    {
        static MakePropArt()
        {
            foreach (ThingDef def in from d in DefDatabase<ThingDef>.AllDefs where d.recipeMaker != null select d)
            {
                if (def.IsArt)
                {

                }
            }
            //DefDatabase<ThingDef>.Add(new Building());
            //ThingCategoryDef arts = ThingCategoryDefOf.BuildingsArt;
            ////foreach (Building r in )
            //    for (ThingCategoryDef thingCategoryDef = this.thingCategories[i]; thingCategoryDef != null; thingCategoryDef = thingCategoryDef.parent)
            //    {
            //        if (thingCategoryDef == category)
            //        {
            //            return true;
            //        }
            //    }
            //}
        }
    }
}
