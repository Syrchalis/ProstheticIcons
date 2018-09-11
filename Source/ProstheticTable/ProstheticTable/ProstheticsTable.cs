using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace ProstheticsTable
{
    [DefOf]
    public static class ProstheticsTableDefOf
    {
        public static ThingDef TableSyrProsthetics;
    }

    public class ProstheticsTableSettings : ModSettings
    {

        public override void ExposeData()
        {
            base.ExposeData();
        }
    }

    public class ProstheticsTableMod : Mod
    {
        public static ProstheticsTableSettings settings;

        public ProstheticsTableMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<ProstheticsTableSettings>();
        }
        public static void SortRecipes()
        {
            foreach (RecipeDef rDef in DefDatabase<RecipeDef>.AllDefs)
            {
                if (rDef.recipeUsers.Contains(ProstheticsTableDefOf.TableSyrProsthetics))
                {

                }
            }
        }
    }
}
