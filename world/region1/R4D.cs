using MelonLoader;
using UnityEngine;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public class R4D {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R4D)").gameObject;
            if (!roomReference) {
                MelonLogger.Error("R4D Room Reference not found!");
                return;
            }
            GameObject flyingEnemy1 = roomReference.transform.Find("FlyingEnemy").gameObject;
            Object.DestroyImmediate(flyingEnemy1?.GetComponent<FlyingEnemy>());
            flyingEnemy1?.AddComponent<KaizoFlyingEnemy>();
            flyingEnemy2 = Object.Instantiate(flyingEnemy1);
            flyingEnemy2.transform.SetParent(roomReference.transform);
            flyingEnemy2.transform.localPosition = new Vector3(4f, -2f, 0f);
            flyingEnemy3 = Object.Instantiate(flyingEnemy1);
            flyingEnemy3.transform.SetParent(roomReference.transform);
            flyingEnemy3.transform.localPosition = new Vector3(0f, -20f, 0f);
        }
        public static GameObject roomReference;
        public static GameObject flyingEnemy1;
        public static GameObject flyingEnemy2;
        public static GameObject flyingEnemy3;
    }
}