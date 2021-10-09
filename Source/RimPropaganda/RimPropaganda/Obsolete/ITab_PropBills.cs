using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Sound;


//TODO:
//modify bill class to have a propaganda button if there is art
//modify production behavior to make art reflect this setting

/**
 * Useful classes:
 * Bill: An individual option for crafting
 * GenRecipe: Set art to have the correct properties when done
 */
namespace RimPropoganda
{
  //  class ITab_PropBills : ITab_Bills
  //  {
		//protected override void FillTab()
		//{
		//	PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.BillsTab, KnowledgeAmount.FrameDisplayed);
		//	Rect rect = new Rect(size.x - PasteX, PasteY, PasteSize, PasteSize);
		//	if (BillUtility.Clipboard != null)
		//	{
		//		if (!this.SelTable.def.AllRecipes.Contains(BillUtility.Clipboard.recipe) || !BillUtility.Clipboard.recipe.AvailableNow || !BillUtility.Clipboard.recipe.AvailableOnNow(this.SelTable, null))
		//		{
		//			GUI.color = Color.gray;
		//			Widgets.DrawTextureFitted(rect, TexButton.Paste, 1f);
		//			GUI.color = Color.white;
		//			if (Mouse.IsOver(rect))
		//			{
		//				TooltipHandler.TipRegion(rect, "ClipboardBillNotAvailableHere".Translate() + ": " + BillUtility.Clipboard.LabelCap);
		//			}
		//		}
		//		else if (this.SelTable.billStack.Count >= 15)
		//		{
		//			GUI.color = Color.gray;
		//			Widgets.DrawTextureFitted(rect, TexButton.Paste, 1f);
		//			GUI.color = Color.white;
		//			if (Mouse.IsOver(rect))
		//			{
		//				TooltipHandler.TipRegion(rect, "PasteBillTip".Translate() + " (" + "PasteBillTip_LimitReached".Translate() + "): " + BillUtility.Clipboard.LabelCap);
		//			}
		//		}
		//		else
		//		{
		//			if (Widgets.ButtonImageFitted(rect, TexButton.Paste, Color.white))
		//			{
		//				Bill bill = BillUtility.Clipboard.Clone();
		//				bill.InitializeAfterClone();
		//				this.SelTable.billStack.AddBill(bill);
		//				SoundDefOf.Tick_Low.PlayOneShotOnCamera(null);
		//			}
		//			if (Mouse.IsOver(rect))
		//			{
		//				TooltipHandler.TipRegion(rect, "PasteBillTip".Translate() + ": " + BillUtility.Clipboard.LabelCap);
		//			}
		//		}
		//	}
		//	Rect rect2 = new Rect(0f, 0f, size.x, size.y).ContractedBy(10f);

		//	//
		//	Func<List<FloatMenuOption>> recipeOptionsMaker = delegate ()
		//	{
		//		List<FloatMenuOption> optList = new List<FloatMenuOption>();
		//		for (int i = 0; i < this.SelTable.def.AllRecipes.Count; i++)
		//		{
		//			if (this.SelTable.def.AllRecipes[i].AvailableNow && this.SelTable.def.AllRecipes[i].AvailableOnNow(this.SelTable, null))
		//			{
		//				RecipeDef curRecipe = this.SelTable.def.AllRecipes[i];
		//				foreach (Ideo ideo in Faction.OfPlayer.ideos.AllIdeos)
		//				{
		//					foreach (Precept_Building precept_Building in ideo.cachedPossibleBuildings)
		//					{
		//						if (precept_Building.ThingDef == curRecipe.ProducedThingDef)
		//						{
		//							//public FloatMenuOption(string label, Action action, MenuOptionPriority priority = MenuOptionPriority.Default, Action<Rect> mouseoverGuiAction = null, Thing revalidateClickTarget = null, float extraPartWidth = 0f, Func<Rect, bool> extraPartOnGUI = null, WorldObject revalidateWorldClickTarget = null, bool playSelectionSound = true, int orderInPriority = 0)
		//							//optList.Add(new FloatMenuOption());
		//						}
		//					}
		//				}
		//			}
		//		}
		//		if (!optList.Any<FloatMenuOption>())
		//		{
		//			optList.Add(new FloatMenuOption("NoneBrackets".Translate(), null, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0));
		//		}
		//		return optList;
		//	};

		//	this.mouseoverBill = this.SelTable.billStack.DoListing(rect2, recipeOptionsMaker, ref this.scrollPosition, ref this.viewHeight);
		//}

		//private float viewHeight = 1000f;

		//private Vector2 scrollPosition;

		//private Bill mouseoverBill;

		//[TweakValue("Interface", 0f, 128f)]
		//private static float PasteX = 48f;

		//[TweakValue("Interface", 0f, 128f)]
		//private static float PasteY = 3f;

		//[TweakValue("Interface", 0f, 32f)]
		//private static float PasteSize = 24f;
	//}
}
