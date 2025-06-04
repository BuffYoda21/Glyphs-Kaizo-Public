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
            roomReference.transform.Find("SaveConditional").gameObject.SetActive(false);    //Might move to the other side of the pit to force players to go back and grab the save button
        }
        
        private static GameObject roomReference;
    }
}