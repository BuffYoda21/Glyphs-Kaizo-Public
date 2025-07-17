using UnityEngine;
using MelonLoader;
using Il2CppInterop.Runtime.Injection;
using GlyphsKaizo.World;
using GlyphsKaizo.Bosses.Spearman;
using GlyphsKaizo.defense;
using GlyphsKaizo.Scripts.Puzzles;

[assembly: MelonInfo(typeof(GlyphsKaizo.Main), "Glyphs Kaizo", "1.0.0-Dev.8.5", "BuffYoda21")]
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
            InjectKaizoClasses();           
            GameObject worldManager = new GameObject("KaizoWorldManager");
            UnityEngine.Object.DontDestroyOnLoad(worldManager);
            worldManager.AddComponent<KaizoWorldManager>();
            //worldManager.AddComponent<TheNuke>();
            //obj.AddComponent<TheWatch>();
            MelonLogger.Msg("Glyphs Kaizo loaded successfully!");
            Debug.Log("I know you are reading this Landon lolllllll");
            isInitialized = true;
        }

        private void InjectKaizoClasses() {
            MelonLogger.Msg("Injecting Custom Kaizo Classes...");
            ClassInjector.RegisterTypeInIl2Cpp<KaizoWorldManager>();
            ClassInjector.RegisterTypeInIl2Cpp<KaizoSpearBoss>();                   //probably gonna rework boss loading to a master loader and inject that instead
            ClassInjector.RegisterTypeInIl2Cpp<KaizoSpearBossCoroutineHelper>();
            ClassInjector.RegisterTypeInIl2Cpp<KaizoFloorEnemy>();
            //ClassInjector.RegisterTypeInIl2Cpp<TheWatch>();
            //ClassInjector.RegisterTypeInIl2Cpp<TheNuke>();
            ClassInjector.RegisterTypeInIl2Cpp<Frag1>();                            //probably going to move puzzle scripts into a seperate puzzle loader later
        }

        bool isInitialized = false;
    }
}