using System;
using System.Collections;
using System.Collections.Generic;
using Modding;
using UnityEngine;
using Satchel;

namespace QuickDive
{
    public class QuickDive : Mod
    {
        new public string GetName() => "QuickDive";

        public override string GetVersion() => "1.0.0.0";

        public override void Initialize()
        {
            On.HeroController.Awake += OnHeroAwake;
            ModHooks.LanguageGetHook += LanguageGet;
        }

        private void OnHeroAwake(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);
            HeroController.instance.spellControl.ChangeTransition("Can Cast? QC", "FINISHED", "Has Quake?");
        }

        private string LanguageGet(string key, string sheetTitle, string orig)
        {
            if (key == "BUTTON_QCAST" && sheetTitle == "MainMenu")
                return "Quick Dive";
            return orig;
        }
    }
}
