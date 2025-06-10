using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public class R1C
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R1C)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R1C Room Reference not found!");
                return;
            }
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(-1f, -2.1f, 0f);
            respawnPoint.name = "RespawnPoint";
            spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, false);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike2 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike3 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike4 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike5 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike6 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike7 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike8 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike9 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike10 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            spike1.name = "Magic Spike";
            spike2.name = "Magic Spike (1)";
            spike3.name = "Magic Spike (2)";
            spike4.name = "Magic Spike (3)";
            spike5.name = "Magic Spike (4)";
            spike6.name = "Magic Spike (5)";
            spike7.name = "Magic Spike (6)";
            spike8.name = "Magic Spike (7)";
            spike9.name = "Magic Spike (8)";
            spike10.name = "Magic Spike (9)";
            spike1.transform.localPosition = new Vector3(-11.8f, -17.7f, 0f);
            spike1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike2.transform.localPosition = new Vector3(-10.6f, -17.7f, 0f);
            spike2.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike3.transform.localPosition = new Vector3(-9.4f, -17.7f, 0f);
            spike3.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike4.transform.localPosition = new Vector3(-8.2f, -17.7f, 0f);
            spike4.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike5.transform.localPosition = new Vector3(-7f, -17.7f, 0f);
            spike5.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike6.transform.localPosition = new Vector3(-5.8f, -17.7f, 0f);
            spike6.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike7.transform.localPosition = new Vector3(-4.6f, -17.7f, 0f);
            spike7.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            tileParent = roomReference.transform.Find("Tiles").gameObject;
            tileParent.transform.Find("Door (5)").localPosition = new Vector3(-10.25f, -19f, 0f);
            tileParent.transform.Find("Door (5)").localRotation = Quaternion.Euler(0f, 0f, 90f);
            // probably gonna add a large door to stop you from going down to R1E early. Probably
            // using a green button. Still need to open a hole in the right wall to access R2D.
            // definitely still gonna need more spikes everywhere. Not sure about the logic required
            // for going back up. Figure that out later.
        }

        private static GameObject roomReference;
        private static GameObject spikeParent;
        private static GameObject tileParent;
    }
}