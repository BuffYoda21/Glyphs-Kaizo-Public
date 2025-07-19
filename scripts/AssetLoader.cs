using Il2Cpp;
using UnityEngine;
namespace GlyphsKaizo.scripts {
    public class AssetLoader {
        public static void init() {
            assetParent = new GameObject("KaizoCustomAssets");
            UnityEngine.Object.DontDestroyOnLoad(assetParent);
            initalized = true;
        }

        public static GameObject Load(string name) {
            if (!initalized) init();
            switch (name) {
                case "bigLaser": return LoadBigLaser();
            }
            return null;
        }

        private static GameObject LoadBigLaser() {
            Transform existing = assetParent.transform.Find("BigLaser");
            if (existing != null) {
                return existing.gameObject; // Return the existing template
            }
            GameObject laser = new GameObject("BigLaser");
            laser.transform.SetParent(assetParent.transform);
            laser.SetActive(false);
            laser.transform.localScale = new Vector3(1f, 200f, 1f);
            BoxCollider2D bc = laser.AddComponent<BoxCollider2D>();
            bc.size = new Vector2(1f, 1f);
            bc.isTrigger = true;
            AttackBox ab = laser.AddComponent<AttackBox>();
            ab.attackType = "enemy";
            ab.damage = 35;
            ab.multihit = true;
            SpriteRenderer sr = laser.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<GameObject>("prefabs/betweenrooms/Room1  _ _").transform.Find("wall").GetComponent<SpriteRenderer>().sprite;
            sr.size = new Vector2(1f, 1f);
            sr.color = new Color(1f, 0f, 0f, .6f);
            return laser;
        }

        public static GameObject assetParent;
        public static bool initalized = false;
    }
}