using UnityEngine;
using MelonLoader;
using Il2CppInterop.Runtime.Injection;
using GlyphsKaizo.World;
using GlyphsKaizo.Bosses.Spearman;
using GlyphsKaizo.defense;

[assembly: MelonInfo(typeof(GlyphsKaizo.Main), "Glyphs Kaizo", "1.0.0-Dev.5.2", "BuffYoda21")]
[assembly: MelonGame("Vortex Bros.", "GLYPHS")]

namespace GlyphsKaizo {
    public class Main : MelonMod {
        [System.Obsolete]
        public override void OnApplicationStart() {
            if (isInitialized) {
                MelonLogger.Msg("Glyphs Kaizo is already initialized.");
                return;
            }
            var harmony = new HarmonyLib.Harmony("GlyphsKaizo.Patches");
            harmony.PatchAll();
            MelonLogger.Msg("Injecting Custom Kaizo Classes...");
            ClassInjector.RegisterTypeInIl2Cpp<KaizoWorldManager>();
            ClassInjector.RegisterTypeInIl2Cpp<KaizoSpearBoss>();                   //probably gonna rework boss loading to a master loader and inject that instead
            ClassInjector.RegisterTypeInIl2Cpp<KaizoSpearBossCoroutineHelper>();
            //ClassInjector.RegisterTypeInIl2Cpp<TheWatch>();                         //redundant after the nuke is detonated
            ClassInjector.RegisterTypeInIl2Cpp<TheNuke>();
            GameObject worldManager = new GameObject("KaizoWorldManager");
            UnityEngine.Object.DontDestroyOnLoad(worldManager);
            worldManager.AddComponent<KaizoWorldManager>();
            worldManager.AddComponent<TheNuke>();
            //obj.AddComponent<TheWatch>();                                         //redundant after the nuke is detonated
            MelonLogger.Msg("Glyphs Kaizo loaded successfully!");
            isInitialized = true;
        }

        bool isInitialized = false;
    }
}