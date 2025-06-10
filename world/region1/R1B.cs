using UnityEngine;
using MelonLoader;

namespace GlyphsKaizo.World.Region1
{
    public class R1B
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R1B)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R1B Room Reference not found!");
                return;
            }
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(6.5f, -1.9f, 0f);
            respawnPoint.name = "RespawnPoint";
            spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, false);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            spike1.transform.localPosition = new Vector3(4.95f, -6.65f, 0f);
            spike1.name = "Magic Spike";
            tileParent = roomReference.transform.Find("Tiles").gameObject;
            tileParent.transform.Find("Square (27)").gameObject.SetActive(false);   // lol troll
        }

        private static GameObject roomReference;
        private static GameObject spikeParent;
        private static GameObject tileParent;
    }
}