using UnityEngine;
using MelonLoader;
using Il2Cpp;

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
            spike1.transform.localPosition = new Vector3(4.2f, -6.65f, 0f);
            spike1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike2.transform.localPosition = new Vector3(-4f, -2.7f, 0f);
            spike2.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike3.transform.localPosition = new Vector3(-1.4f, -8.6f, 0f);
            spike3.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike3.transform.localScale = new Vector3(1f, 0.7f, 1f);
            spike4.transform.localPosition = new Vector3(5.4f, -6.65f, 0f);
            spike4.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike5.transform.localPosition = new Vector3(-11.6f, -15.2f, 0f);
            spike5.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike6.transform.localPosition = new Vector3(-10.4f, -15.2f, 0f);
            spike6.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike7.transform.localPosition = new Vector3(-9.2f, -15.2f, 0f);
            spike7.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike8.transform.localPosition = new Vector3(-8f, -15.2f, 0f);
            spike8.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike9.transform.localPosition = new Vector3(-6.8f, -15.2f, 0f);
            spike9.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike10.transform.localPosition = new Vector3(-5.6f, -15.2f, 0f);
            spike10.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            tileParent = roomReference.transform.Find("Tiles").gameObject;
            tileParent.transform.Find("Square (27)").gameObject.SetActive(false);   // lol troll
            GameObject bouncePad = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Bounce Box - H"), roomReference.transform);
            bouncePad.transform.localPosition = new Vector3(-2f, -11f, 0f);
            bouncePad.transform.localScale = new Vector3(2f, 0.3f, 1f);
            bouncePad.GetComponent<BouncePlatform>().xstrength = 1.6f;
            bouncePad.GetComponent<BouncePlatform>().ystrength = 0.3f;
            bouncePad.GetComponent<BouncePlatform>().yaxis = true;
            bouncePad.name = "Bounce Pad";
        }

        private static GameObject roomReference;
        private static GameObject spikeParent;
        private static GameObject tileParent;
    }
}