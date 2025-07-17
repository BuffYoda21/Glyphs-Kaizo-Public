using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1 {
    public class R3D
    {
        public static void Load(GameObject regionReference, KaizoWorldManager worldManager)
        {
            roomReference = regionReference.transform.Find("(R3D)(sword)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R3D Room Reference not found!");
                return;
            }
            sword = Object.Instantiate(worldManager.sword, roomReference.transform);
            sword.transform.localPosition = new Vector3(0f, -3.3f, 0f);
            sword.SetActive(true);
        }

        private static GameObject roomReference;
        private static GameObject sword;
    }
}