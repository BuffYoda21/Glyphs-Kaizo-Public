using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using GlyphsKaizo.defense;

namespace GlyphsKaizo.World.Region1 {
    [HarmonyPatch]
    public static class Region1Master
    {
        [HarmonyPatch(typeof(SceneManager), "Internal_SceneLoaded")]
        [HarmonyPostfix]
        public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.handle == lastSceneHandle)
                return;
            lastSceneHandle = scene.handle;
            //MelonLogger.Msg($"Scene loaded: {scene.name}");
            if (scene.name == "Game")
            {
                initializationTime = Time.time;
                worldManager = GameObject.Find("KaizoWorldManager").GetComponent<KaizoWorldManager>();
                worldManager.GetComponent<TheNuke>().RegisterTargets();
                worldManager.CacheItems();
                regionReference = GameObject.Find("/World/Region1");
                if (regionReference == null)
                {
                    MelonLogger.Error("Region1 not found!");
                    return;
                }
                R1A.Load(regionReference);
                R2A.Load(regionReference);
                R3A.Load(regionReference);
                R4A.Load(regionReference);
                R1B.Load(regionReference);
                R2B.Load(regionReference, worldManager);
                R3B.Load(regionReference);
                R4B.Load(regionReference);
                R1C.Load(regionReference);
                initializationTime = Time.time - initializationTime;
                MelonLogger.Msg($"Region1 initialization complete in {initializationTime:F2} second(s).");
            }
        }

        private static GameObject regionReference;
        private static int lastSceneHandle = -1;
        private static float initializationTime = 0;
        private static KaizoWorldManager worldManager;
    }
}