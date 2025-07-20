using Il2Cpp;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;

namespace GlyphsKaizo.enemies {
    [HarmonyPatch]
    public class BossLoader {
        [HarmonyPatch(typeof(SceneManager), "Internal_SceneLoaded")]
        [HarmonyPostfix]
        public static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (scene.handle == lastSceneHandle)
                return;
            lastSceneHandle = scene.handle;
            //MelonLogger.Msg($"Scene loaded: {scene.name}");
            if (scene.name != "Game" && scene.name != "Memory") return;
            bossAI = DetectBoss();
            switch (bossAI) {
                case DashBoss dashBoss:
                    bossAI.gameObject.AddComponent<KaizoDashBoss>();
                    break;
            }
            Object.Destroy(bossAI);
        }

        //Add more boss detection as needed
        private static MonoBehaviour DetectBoss() {
            bossAI = null;
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name) {
                case "Game":
                    bossAI = GameObject.Find("World/Region1/Runic Construct(R3E)/DashBoss").GetComponent<DashBoss>();
                    break;
                case "Memory":
                    bossAI = GameObject.Find("World/Construct Memory/Runic Construct(R3E)/DashBoss").GetComponent<DashBoss>();
                    break;
            }
            if (bossAI && bossAI.isActiveAndEnabled)
                return bossAI;
            return null;
        }

        private static int lastSceneHandle = -1;
        private static MonoBehaviour bossAI;
    }
}