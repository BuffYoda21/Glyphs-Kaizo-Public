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
                    if (dashBoss.gameObject.GetComponent<KaizoDashBoss>()) return;
                    KaizoDashBoss kaizoDashBoss = dashBoss.gameObject.AddComponent<KaizoDashBoss>();
                    kaizoDashBoss.orbparent = dashBoss.orbparent;
                    GameObject orb1 = kaizoDashBoss.orbparent.transform.Find("AttackOrb").gameObject;
                    GameObject orb2 = kaizoDashBoss.orbparent.transform.Find("AttackOrb (1)").gameObject;
                    orb1.AddComponent<KaizoAttackOrb>();
                    DestroyImmediate(orb1.GetComponent<DashBossAttackOrb>());
                    orb2.AddComponent<KaizoAttackOrb>();
                    DestroyImmediate(orb2.GetComponent<DashBossAttackOrb>());
                    orb1.GetComponent<KaizoAttackOrb>().init();
                    orb2.GetComponent<KaizoAttackOrb>().init();
                    kaizoDashBoss.init();
                    kaizoDashBoss.orbs = new KaizoAttackOrb[2];
                    kaizoDashBoss.orbs[0] = orb1.GetComponent<KaizoAttackOrb>();
                    kaizoDashBoss.orbs[1] = orb2.GetComponent<KaizoAttackOrb>();
                    kaizoDashBoss.onPhase3 = dashBoss.onPhase3;
                    kaizoDashBoss.orbspeed = dashBoss.orbspeed;
                    kaizoDashBoss.spike = dashBoss.spike;
                    kaizoDashBoss.bb = dashBoss.bb;
                    break;
            }
            if (bossAI) DestroyImmediate(bossAI);
        }

        //Add more boss detection as needed
        private MonoBehaviour DetectBoss() {
            MonoBehaviour bossAI = null;
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name) {
                case "Game":
                    bossAI = GameObject.Find("World/Region1/Runic Construct(R3E)/DashBoss")?.GetComponent<DashBoss>();
                    break;
                case "Memory":
                    bossAI = GameObject.Find("World/Construct Memory/Runic Construct(R3E)/DashBoss")?.GetComponent<DashBoss>();
                    break;
            }
            if (bossAI && bossAI.isActiveAndEnabled)
                return bossAI;
            return null;
        }
    }
}