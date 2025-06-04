using System.Collections;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlyphsKaizo.Bosses.Spearman
{
    [HarmonyPatch]
    public static class KaizoSpearTrigger
    {
        [HarmonyPatch(typeof(SceneManager), "Internal_SceneLoaded")]
        [HarmonyPostfix]
        public static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (scene.name == "Memory" || scene.name == "Game") {
                MelonCoroutines.Start(DelayedCall());
            }
        }

        private static IEnumerator DelayedCall() {
            yield return new WaitForSeconds(0.2f);
            CheckForSpearman();
        }

        private static void CheckForSpearman() {
            GameObject spearman = GameObject.Find("/World/Spearman Memory/(R0E)>(R1D)/Spearman");
            if (spearman != null && spearman.activeInHierarchy) {
                KaizoSpearmanMain.Initialize(spearman);
            }
            else {
                spearman = GameObject.Find("/World/Region2/Sector 3/(R0E)>(R1D)/Spearman");
                if (spearman != null && spearman.activeInHierarchy && spearman.GetComponent<SpearBoss>().isActiveAndEnabled) {
                    KaizoSpearmanMain.Initialize(spearman);
                }
            }
        }

        private static string GetGameObjectPath(GameObject obj) {
            string path = "/" + obj.name;
            while (obj.transform.parent != null) {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            return path;
        }
    }
}
