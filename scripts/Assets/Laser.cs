using GlyphsKaizo.Scripts;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace GlyphsKaizo.scripts.Assets {
    [RegisterTypeInIl2Cpp]
    public class Laser : MonoBehaviour {
        public void Start() {
            ab = base.GetComponent<AttackBox>();
            sr = base.GetComponent<SpriteRenderer>();
            bc = base.GetComponent<BoxCollider2D>();
            camHover = GameObject.Find("Main Camera Parent")?.GetComponent<Hover>();
            warningTimer = Time.time + warningTime;
        }

        public void Update() {
            if (firing && Time.time > durationTimer) {
                if (camShake)
                    camHover.enabled = false;
                Destroy(this.gameObject);
            }
            if (!charging && !firing) {
                this.transform.localScale = new Vector3(0.05f, this.transform.localScale.y, 1f);
                this.bc.enabled = false;
                charging = true;
            }
            if (charging) {
                if (Time.time > warningTimer) {
                    durationTimer = Time.time + duration;
                    this.transform.localScale = new Vector3(width, this.transform.localScale.y, 1f);
                    camHover.enabled = true;
                    camShake = true;
                    camShakeTimer = Time.time + camShakeDuration;
                    bc.enabled = true;
                    firing = true;
                    charging = false;
                }
            }
            if (camShake && Time.time > camShakeTimer) {
                camHover.enabled = false;
                camShake = false;
            }
        }

        public Hover camHover;
        public bool camShake = false;
        public float camShakeTimer = 0f;
        public float camShakeDuration = 0.5f;
        public bool charging = false;
        public bool firing = false;
        public float duration = 1f;
        public float warningTime = 1.5f;
        public float durationTimer = 0f;
        public float warningTimer = 0f;
        public int width = 1;
        public AttackBox ab;
        public SpriteRenderer sr;
        public BoxCollider2D bc;
    }
}