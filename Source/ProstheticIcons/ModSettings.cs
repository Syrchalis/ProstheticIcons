using Harmony; //harmony is used only for the traverse method, no method is patched here
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using Verse;
using static Harmony.AccessTools;

namespace Syrchalis_ProstheticIcons
{
    /*public class ProstheticIconsSettings : ModSettings
    {
        //public bool patchIcons = true;
        //public bool colorIcons = true;

        public override void ExposeData()
        {
            base.ExposeData();
            //Scribe_Values.Look(ref patchIcons, "patchIcons", true);
            //Scribe_Values.Look(ref colorIcons, "colorIcons", true);
        }
    }*/

    [StaticConstructorOnStartup]
    public static class ThingDefsPatch
    {
        static ThingDefsPatch()
        {
            ProstheticIcons.PatchIcons();
            ProstheticIcons.ColorIcons();
        }
    }

    public class ProstheticIcons : Mod
    {
        //public static ProstheticIconsSettings settings;

        public ProstheticIcons(ModContentPack content) : base(content)
        {
            //settings = GetSettings<ProstheticIconsSettings>();
        }

        /*public override string SettingsCategory() => "ProstheticIconsCategoryLabel".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.AddLabeledCheckbox("patchIconsLabel".Translate() + ": ", ref settings.patchIcons);
            listing_Standard.AddLabeledCheckbox("colorIconsLabel".Translate() + ": ", ref settings.colorIcons);
            listing_Standard.End();
            settings.Write();
        }*/

        //Looks at defnames and assigns icons based on key strings
        public static void PatchIcons()
        {
            foreach (ThingDef tDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (tDef.isTechHediff && 
                    !tDef.defName.Contains("WoodLog", StringComparison.OrdinalIgnoreCase) && 
                    !tDef.defName.Contains("Lumber", StringComparison.OrdinalIgnoreCase) && 
                    !tDef.defName.Contains("Bamboo", StringComparison.OrdinalIgnoreCase) &&
                    !tDef.defName.Equals("SteelThrumkinHorn") &&
                    !tDef.defName.Equals("EnhancementThrumkinHorn"))
                {
                    tDef.graphicData.graphicClass = typeof(Graphic_StackCount);
                    tDef.graphicData.drawSize = new Vector2 (1.0f, 1.0f);
                    if (tDef.defName.Contains("Arm", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tDef.defName.Contains("Claw", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Power", StringComparison.OrdinalIgnoreCase))
                        {
                            tDef.graphicData.texPath = "Things/Item/Health/HealthItemPowerArm";
                        }
                        else
                        {
                            tDef.graphicData.texPath = "Things/Item/Health/HealthItemArm";
                        }
                    }
                    else if (tDef.defName.Contains("Claw", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemClaw";
                    }
                    //cochlear contains "ear" so no need to look for it, "heart" needs to be excluded because it also contains ear
                    else if (tDef.defName.Contains("Ear", StringComparison.OrdinalIgnoreCase) && !tDef.defName.Contains("Heart", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemEar";
                    }
                    else if (tDef.defName.Contains("Eye", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemEye";
                    }
                    else if (tDef.defName.Contains("Foot", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemFoot";
                    }
                    else if (tDef.defName.Contains("Hand", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemHand";
                    }
                    else if (tDef.defName.Contains("Heart", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemHeart";
                    }
                    else if (tDef.defName.Contains("Jaw", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Denture", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemJaw";
                    }
                    else if (tDef.defName.Contains("Kidney", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemKidney";
                    }
                    else if (tDef.defName.Contains("Leg", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemLeg";
                    }
                    else if (tDef.defName.Contains("Liver", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemLiver";
                    }
                    else if (tDef.defName.Contains("Lung", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemLung";
                    }
                    else if (tDef.defName.Contains("Nose", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemNose";
                    }
                    else if (tDef.defName.Contains("Pelvis", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemPelvis";
                    }
                    else if (tDef.defName.Contains("Ribcage", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemRibcage";
                    }
                    else if (tDef.defName.Contains("Spine", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemSpine";
                    }
                    else if (tDef.defName.Contains("Sternum", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemSternum";
                    }
                    else if (tDef.defName.Contains("Stomach", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemStomach";
                    }
                    else if (tDef.defName.Contains("Tail", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemTail";
                    }
                    else if (tDef.defName.Contains("Torso", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Exoskeleton", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Suit", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemTorso";
                    }
                    //Special cases
                    else if (tDef.defName.Contains("Bone", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemBone";
                    }
                    else if (tDef.defName.Contains("Joywire", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemJoywire";
                    }
                    else if (tDef.defName.Contains("Painstopper", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemPainstopper";
                    }
                    else if (tDef.defName.Contains("Obliterator", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("DeathClaw", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemPowerArm";
                    }
                    //Fallback
                    else
                    {
                        tDef.graphicData.texPath = "Things/Item/Health/HealthItemMisc";
                    }
                    //Forces "Init" to run again, which creates graphics
                    Traverse.Create(tDef.graphicData).Method("Init").GetValue();
#if DEBUG
                    Log.Message(tDef.defName + " | " + tDef.graphicData.texPath + " | " + tDef.graphicData.Graphic);
#endif
                }
            }
        }

        //Looks at defnames and assigns colors based on key strings
        public static void ColorIcons()
        {
            foreach (ThingDef tDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (tDef.isTechHediff && 
                    !tDef.defName.Contains("WoodLog", StringComparison.OrdinalIgnoreCase) && 
                    !tDef.defName.Contains("Lumber", StringComparison.OrdinalIgnoreCase) && 
                    !tDef.defName.Contains("Bamboo", StringComparison.OrdinalIgnoreCase) &&
                    !tDef.defName.Equals("SteelThrumkinHorn") &&
                    !tDef.defName.Equals("EnhancementThrumkinHorn"))
                {
                    if (tDef.defName.Contains("Animal", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tDef.defName.Contains("Bionic", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Brain", StringComparison.OrdinalIgnoreCase))
                        {
                            tDef.graphicData.color = new Color(0.59f, 0.78f, 0.9f, 1f);
                        }
                        else
                        {
                            tDef.graphicData.color = new Color(0.31f, 0.51f, 0.63f, 1f);
                        }
                    }
                    else if (tDef.defName.Contains("Natural", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.color = new Color(1f, 1f, 1f, 1f);
                    }
                    else if (tDef.defName.Contains("Simple", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Prosthetic", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Artificial", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Cochlear", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Basic", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.color = new Color(0.78f, 0.63f, 0.51f, 1f);
                    }
                    else if (tDef.defName.Contains("Bionic", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Joywire", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Painstopper", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("PowerClaw", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.color = new Color(1f, 0.9f, 0.59f, 1f);
                    }
                    else if (tDef.defName.Contains("Archotech", StringComparison.OrdinalIgnoreCase) || tDef.defName.Contains("Advanced", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tDef.defName.Contains("Archotech", StringComparison.OrdinalIgnoreCase) && tDef.defName.Contains("Advanced", StringComparison.OrdinalIgnoreCase))
                        {
                            tDef.graphicData.color = new Color(0.78f, 0.86f, 0.71f, 1f);
                        }
                        else
                        {
                            tDef.graphicData.color = new Color(0.71f, 0.59f, 0.9f, 1f);
                        }
                    }
                    //Special cases
                    else if (tDef.defName.Contains("PlasteelClaws", StringComparison.OrdinalIgnoreCase))
                    {
                        tDef.graphicData.color = new Color(0.78f, 0.63f, 0.51f, 1f);
                    }
                    //Fallback
                    else
                    {
                        tDef.graphicData.color = new Color(1f, 1f, 1f, 1f);
                    }
                    tDef.ResolveReferences();
                }
            }
        }
    }



        public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
    //USAGE:
    //string title = "STRING";
    //bool contains = title.Contains("string", StringComparison.OrdinalIgnoreCase);
}