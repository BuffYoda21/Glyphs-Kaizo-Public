using UnityEngine;
using MelonLoader;

namespace GlyphsKaizo.World.Region1{
    public class R1A {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R1A)(EntryRoom)").gameObject;
            if (roomReference == null) {
                MelonLogger.Error("R1A Room Reference not found!");
                return;
            }
            GameObject spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, true);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(6.5f, -1.2f, 0f), Quaternion.identity);
            spike1.transform.SetParent(spikeParent.transform, false);
            spike1.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            spike1.name = "Magic Spike";
            GameObject spike2 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(12f, -0.2f, 0f), Quaternion.identity);
            spike2.transform.SetParent(spikeParent.transform, false);
            spike2.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            spike2.name = "Magic Spike (1)";
        }

        private static GameObject roomReference;
    }
}