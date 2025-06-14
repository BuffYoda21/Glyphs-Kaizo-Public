using UnityEngine;
using MelonLoader;
using GlyphsKaizo.Scripts.Puzzles;
using Il2Cpp;

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
            spike9.transform.localPosition = new Vector3(-1.5f, -4.75f, 0f);
            spike10.transform.localPosition = new Vector3(-1.5f, -2.25f, 0f);
            spike11.transform.localPosition = new Vector3(5.5f, -4.75f, 0f);
            spike12.transform.localPosition = new Vector3(5.5f, -2.25f, 0f);
            spike9.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike10.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
            spike11.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike12.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
            spike9.GetComponent<BoxCollider2D>().size = new Vector2(0.9616f, 0.8216f);
            spike10.GetComponent<BoxCollider2D>().size = new Vector2(0.9616f, 0.8216f);
            spike11.GetComponent<BoxCollider2D>().size = new Vector2(0.9616f, 0.8216f);
            spike12.GetComponent<BoxCollider2D>().size = new Vector2(0.9616f, 0.8216f);
            spike9.name = "Magic Spike (8)";
            spike10.name = "Magic Spike (9)";
            spike11.name = "Magic Spike (10)";
            spike12.name = "Magic Spike (11)";
            GameObject button = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Button"), roomReference.transform);
            button.transform.localPosition = new Vector3(38f, -53f, 0f);
            button.transform.Find("Button").GetComponent<ButtonObj>().type = "dash";
            button.transform.Find("Button").GetComponent<ButtonObj>().timePressed = 90f;
            button.transform.Find("Button").GetComponent<SpriteRenderer>().color = new Color(0f, 0.6059f, 1f, 1f);
            button.name = "FragButton";
            roomReference.AddComponent<Frag1>();
        }

        public static GameObject roomReference;
        public static GameObject tileParent;
        public static GameObject spikeParent;
    }
}