using MelonLoader;
using UnityEngine;

namespace GlyphsKaizo.World.Region1
{
    public class R2C {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R2C)").gameObject;
            if (!roomReference) {
                MelonLogger.Error("R2C Room Reference not found!");
                return;
            }
            roomReference.transform.Find("Tiles/FlowerHide").gameObject.SetActive(false);
        }
        public static GameObject roomReference;
    }
}