using Il2Cpp;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlyphsKaizo.enemies {
    public class BossLoader {
        //Add more boss detection as needed
        public static MonoBehaviour DetectBoss() {
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