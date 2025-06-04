using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1 {
    public class R3A {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R3A)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R3A Room Reference not found!");
                return;
            }
            GameObject BrokenSave = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Save Button Broken"), new Vector3(), Quaternion.identity);
            BrokenSave.transform.SetParent(roomReference.transform, false);
            BrokenSave.transform.localPosition = new Vector3(3f, -2.75f, 0f);
            BrokenSave.name = "Save Button Broken";
            BrokenSave.transform.Find("Button").GetComponent<ButtonObj>().additionalsavecondition = "hasSave_0";
            BrokenSave.transform.Find("TPIndicator").GetComponent<MapPin>().appearCondition = "hasSave_0";
            roomReference.transform.Find("Save Button (HDD)").gameObject.SetActive(false);
        }
        
        private static GameObject roomReference;
    }
}