using System.Collections;
using UnityEngine;
using UnityObject = UnityEngine.Object;
using Il2Cpp;
using MelonLoader; 

namespace GlyphsKaizo.Bosses.Spearman {
    public class KaizoSpearBossCoroutineHelper : MonoBehaviour {

        public void Start() {
            MelonCoroutines.Start(WaitForPhaseTwo());
        }
        public IEnumerator WaitForPhaseTwo() {
            if (KaizoSpearBoss.cloned)
                yield break;
            KaizoSpearBoss.cloned = true;
            while (spearman == null)
                yield return null;
            while (spearmanController == null)
                yield return null;
            if (spearman.name != "Spearman")
                yield break;
            while (spearmanController.phase != 2)
                yield return null;
            GameObject clone1 = UnityEngine.Object.Instantiate(KaizoSpearBoss.cleanClone);
            GameObject clone2 = UnityEngine.Object.Instantiate(KaizoSpearBoss.cleanClone);
            KaizoSpearBoss clone1Controller = clone1.GetComponent<KaizoSpearBoss>();
            KaizoSpearBoss clone2Controller = clone2.GetComponent<KaizoSpearBoss>();
            clone1Controller.initialized = false;
            clone2Controller.initialized = false;
            clone1.name = "Spearman(Clone1)";
            clone2.name = "Spearman(Clone2)";
            clone1.transform.position = spearman.transform.position;
            clone2.transform.position = spearman.transform.position;
            if (spearmanController.player.transform.position.x > spearmanController.transform.position.x) {
                spearmanController.LaunchPlayer(new Vector2(25f, 5f));
            }
            else {
                spearmanController.LaunchPlayer(new Vector2(-25f, 5f));
            }
            clone1Controller.GetComponent<EnemyBase>().canDie = false;
            clone2Controller.GetComponent<EnemyBase>().canDie = false;
            /*
                //All of these turn null immediately???
                clone1Controller.spearParent = clone1.transform.Find("/SpearRotate")?.gameObject;
                clone2Controller.spearParent = clone2.transform.Find("/SpearRotate")?.gameObject;
                clone1Controller.spear = clone1.transform.Find("/SpearRotate/Spear")?.gameObject;
                clone2Controller.spear = clone2.transform.Find("/SpearRotate/Spear")?.gameObject;
                clone1Controller.spearPS = clone1Controller.spear.GetComponent<ParticleSpawner>();
                clone2Controller.spearPS = clone2Controller.spear.GetComponent<ParticleSpawner>();
                clone1Controller.spearSR = clone1Controller.spear.GetComponent<SpriteRenderer>();
                clone2Controller.spearSR = clone2Controller.spear.GetComponent<SpriteRenderer>();
            */
            clone1Controller.rb = clone1.GetComponent<Rigidbody2D>();
            clone2Controller.rb = clone2.GetComponent<Rigidbody2D>();
            clone1Controller.sm = spearman.GetComponent<SaveManager>();
            clone2Controller.sm = spearman.GetComponent<SaveManager>();
            clone1Controller.camHover = UnityObject.FindFirstObjectByType<CameraController>().transform.parent.GetComponent<Hover>();
            clone2Controller.camHover = UnityObject.FindFirstObjectByType<CameraController>().transform.parent.GetComponent<Hover>();
            clone1Controller.phase = spearmanController.phase;
            clone2Controller.phase = spearmanController.phase;
            clone1Controller.ai = spearmanController.ai;
            clone2Controller.ai = spearmanController.ai;
            clone1Controller.battleOrigin = spearmanController.battleOrigin;
            clone2Controller.battleOrigin = spearmanController.battleOrigin;
            clone1.GetComponent<KaizoSpearBossCoroutineHelper>().gameObject.SetActive(false);
            clone2.GetComponent<KaizoSpearBossCoroutineHelper>().gameObject.SetActive(false);
            UnityObject.Destroy(clone1.GetComponent<UnityEngine.AudioSource>());
            UnityObject.Destroy(clone2.GetComponent<UnityEngine.AudioSource>());
            spearmanController.movementSpeed = 1.2f;
            clone1.SetActive(true);
            clone2.SetActive(true);
            clone1Controller.attackCD = Time.time + 5f;
            clone1Controller.flightSpeed = 1f;
            clone1Controller.flightTarget = new Vector3(spearman.transform.position.x - 5f, spearman.transform.position.y + 11f, 0f);
            clone1Controller.rb.gravityScale = 0f;
            clone2Controller.attackCD = Time.time + 5f;
            clone2Controller.flightSpeed = 1f;
            clone2Controller.flightTarget = new Vector3(spearman.transform.position.x + 5f, spearman.transform.position.y + 11f, 0f);
            clone2Controller.rb.gravityScale = 0f;
            clone1.transform.Find("PhysicsPartcleSpawner").gameObject.SetActive(true);
            clone1.transform.Find("Wings").gameObject.SetActive(true);
            clone2.transform.Find("PhysicsPartcleSpawner").gameObject.SetActive(true);
            clone2.transform.Find("Wings").gameObject.SetActive(true);
            spearmanController.player.midairJumpsMax = 3;
            MelonCoroutines.Start(WaitToDestroy(clone1Controller));
            MelonCoroutines.Start(WaitToDestroy(clone2Controller));
            clone1Controller.initialized = true;
            clone2Controller.initialized = true;
        }

        private IEnumerator WaitToDestroy(KaizoSpearBoss victim) {
		    while (spearmanController.ebase.hp >= 2f)
			    yield return null;
		    UnityObject.DestroyImmediate(victim);
	    }

        public KaizoSpearBoss spearmanController;
        public GameObject spearman;
    }
}
