using MelonLoader;
using UnityEngine;
using GlyphsKaizo.Scripts;
using Il2CppSystem.Collections.Generic;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public class R2D {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R2D)").gameObject;
            if (!roomReference) {
                MelonLogger.Error("R2D Room Reference not found!");
                return;
            }
            GameObject e = roomReference.transform.Find("FloorEnemy").gameObject;
            if (e) e.transform.localPosition = new Vector3(e.transform.localPosition.x - 2, e.transform.localPosition.y, e.transform.localPosition.z);
            Object.DestroyImmediate(e?.GetComponent<EnemyFloor>());
            e?.AddComponent<KaizoFloorEnemy>();
            enemies = Utils.Pattern(e, Utils.axis.X, 3, 2);
        }
        public static GameObject roomReference;
        public static List<GameObject> enemies;
    }
}