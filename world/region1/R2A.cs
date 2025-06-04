using UnityEngine;
using MelonLoader;

namespace GlyphsKaizo.World.Region1{
    public class R2A {
        public static void Load(GameObject regionReference) {
            roomReference = regionReference.transform.Find("(R2A)").gameObject;
            if (roomReference == null) {
                MelonLogger.Error("R2A Room Reference not found!");
                return;
            }
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(-10f, 0.4f, 0f);
            roomReference.transform.Find("R2A").gameObject.SetActive(false);
            tileParent = roomReference.transform.Find("Tiles").gameObject;
            tileParent.transform.Find("Square (4)").localPosition = new Vector3(-2f, 0f, 0f);
            tileParent.transform.Find("Square (4)").localScale = new Vector3(1.5f, 2f, 1f);
            tileParent.transform.Find("Square (7)").localPosition = new Vector3(2f, 2.5f, 0f);
            tileParent.transform.Find("Square (7)").localScale = new Vector3(1.5f, 2f, 1f);
            tileParent.transform.Find("Square (8)").localPosition = new Vector3(6f, 4.5f, 0f);
            GameObject tile9 = Object.Instantiate(tileParent.transform.Find("Square (7)").gameObject, new Vector3(), Quaternion.identity);
            tile9.transform.SetParent(tileParent.transform, false);
            tile9.name = "Square (9)";
            tile9.transform.localPosition = new Vector3(-6f, -2.4f, 0f);
            spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, false);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(), Quaternion.identity);
            spike1.transform.SetParent(spikeParent.transform, false);
            spike1.name = "Magic Spike";
            spike1.transform.localPosition = new Vector3(2f, -0.75f, 0f);
            spike1.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            GameObject spike2 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(), Quaternion.identity);
            spike2.transform.SetParent(spikeParent.transform, false);
            spike2.name = "Magic Spike (1)";
            spike2.transform.localPosition = new Vector3(2f, 1.2f, 0f);
            spike2.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            //makes platforming way too hard
            //GameObject spike3 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(), Quaternion.identity);
            //spike3.transform.SetParent(spikeParent.transform, false);
            //spike3.transform.localPosition = new Vector3(-2f, 1.3f, 0f);
            //spike3.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            GameObject spike4 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), new Vector3(), Quaternion.identity);
            spike4.transform.SetParent(spikeParent.transform, false);
            spike4.name = "Magic Spike (3)";
            spike4.transform.localPosition = new Vector3(3.9f, -2.7f, 0f);
            spike4.transform.localScale = new Vector3(4f, 1f, 0f);
        }

        private static GameObject roomReference;
        private static GameObject tileParent;
        private static GameObject spikeParent;
    }
}