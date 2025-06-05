using UnityEngine;
using MelonLoader;

namespace GlyphsKaizo.World.Region1 {
    public class R4A {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R4A)").gameObject;
            if (roomReference == null) {
                MelonLogger.Error("R4A Room Reference not found!");
                return;
            }
            roomReference.transform.Find("SaveConditional").localPosition = new Vector3(6.25f, 0f, 0f);
        }
        
        private static GameObject roomReference;
    }
}