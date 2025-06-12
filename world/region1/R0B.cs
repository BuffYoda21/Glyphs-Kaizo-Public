using UnityEngine;
using MelonLoader;

namespace GlyphsKaizo.World.Region1 {
    public class R0B
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R0B) (Fragment1)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R0B Room Reference not found!");
                return;
            }
            tileParent = roomReference.transform.Find("Tiles").gameObject;
            tileParent.transform.Find("Door").gameObject.SetActive(false);
            tileParent.transform.Find("Door (1)").gameObject.SetActive(false);
            roomReference.transform.Find("Button").gameObject.SetActive(false);
            spikeParent = roomReference.transform.Find("Spikes").gameObject;
            GameObject spike9 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike10 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike11 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike12 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            spike9.transform.localPosition = new Vector3(0f, 0f, 0f);
            spike10.transform.localPosition = new Vector3(0f, 0f, 0f);
            spike11.transform.localPosition = new Vector3(0f, 0f, 0f);
            spike12.transform.localPosition = new Vector3(0f, 0f, 0f);
            spike9.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike10.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike11.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike12.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike9.name = "Magic Spike (8)";
            spike10.name = "Magic Spike (9)";
            spike11.name = "Magic Spike (10)";
            spike12.name = "Magic Spike (11)";
            // add call to start the puzzle logic here
        }

        public static GameObject roomReference;
        public static GameObject tileParent;
        public static GameObject spikeParent;
    }
}