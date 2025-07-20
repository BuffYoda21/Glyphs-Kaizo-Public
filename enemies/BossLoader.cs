using Il2Cpp;
using UnityEngine;
using UnityEngine.SceneManagement;
using MelonLoader;

namespace GlyphsKaizo.enemies {
    [RegisterTypeInIl2Cpp]
    public class BossLoader : MonoBehaviour {
        public void Update() {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "Game" && scene.name != "Memory") return;
            MonoBehaviour bossAI = DetectBoss();
            switch (bossAI) {
                case DashBoss dashBoss:
                    dashBoss.gameObject.AddComponent<KaizoDashBoss>();
                    break;
            }
            if (bossAI) Object.Destroy(bossAI);
        }

        //Add more boss detection as needed
        private MonoBehaviour DetectBoss() {
            MonoBehaviour bossAI = null;
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
    }
}