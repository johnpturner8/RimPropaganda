using Verse;
using UnityEngine;

namespace RimPropaganda
{
    public class PropagandaSettings : ModSettings
    { 
        public float tvPropScale = 1f;
        public float artPropScale = 1f;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref tvPropScale, "tvPropScale", 1f);
            Scribe_Values.Look(ref artPropScale, "artPropScale", 1f);
            base.ExposeData();
        }
    }

    public class PropagandaMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        PropagandaSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public PropagandaMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<PropagandaSettings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Percentage multiplier on TV propaganda: " + this.settings.tvPropScale*100 + "%");
            settings.tvPropScale = listingStandard.Slider(settings.tvPropScale, 0.1f, 10f);
            listingStandard.Label("Percentage multiplier on propaganda art: " + this.settings.artPropScale*100 + "%");
            settings.artPropScale = listingStandard.Slider(settings.artPropScale, 0.1f, 10f);

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "RimPropaganda";
        }
    }
}