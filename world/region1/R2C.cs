using MelonLoader;
using UnityEngine;
using GlyphsKaizo.Scripts;
using Il2CppSystem.Collections.Generic;

namespace GlyphsKaizo.World.Region1
{
    public class R2C {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R2C)").gameObject;
            if (!roomReference) {
                MelonLogger.Error("R0B Room Reference not found!");
                return;
            }
            roomReference.transform.Find("Tiles/FlowerHide").gameObject.SetActive(false);
            enemies = Utils.Pattern(roomReference.transform.Find("FloorEnemy")?.gameObject, Utils.axis.X, 3, 2);
        }
        public static GameObject roomReference;
        public static List<GameObject> enemies;
    }
}