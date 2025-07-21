using UnityEngine;
using MelonLoader;
using GlyphsKaizo.World;
using GlyphsKaizo.scripts;
using GlyphsKaizo.enemies;

[assembly: MelonInfo(typeof(GlyphsKaizo.Main), "Glyphs Kaizo", "1.0.0-pre-1", "BuffYoda21")]
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
            AssetLoader.init();
            GameObject worldManager = new GameObject("KaizoWorldManager");
            UnityEngine.Object.DontDestroyOnLoad(worldManager);
            worldManager.AddComponent<KaizoWorldManager>();
            worldManager.AddComponent<BossLoader>();
            //worldManager.AddComponent<TheNuke>();
            //obj.AddComponent<TheWatch>();
            MelonLogger.Msg("Glyphs Kaizo loaded successfully!");
            Debug.Log("I know you are reading this Landon lolllllll");
            isInitialized = true;
        }
        bool isInitialized = false;
    }
}