using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public class R1E
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R1E)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R1E Room Reference not found!");
                return;
            }
            GameObject gate = roomReference.transform.Find("Launcher (1)").gameObject;
            gate.name = "THE GATE";
            gate.transform.localPosition = new Vector3(-2.5f, 11.5f, 0f);
            gate.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            gate.transform.Find("Door").localPosition = new Vector3(0f, -2.5f, 0f);
            gate.transform.Find("Door").localScale = new Vector3(1f, 2f, 1f);
            gate.transform.Find("Door").localRotation = Quaternion.Euler(0f, 0f, 165f);
            GameObject gateButton1 = gate.transform.Find("Button").gameObject;
            gateButton1.transform.localPosition = new Vector3(7f, -14f, 0f);
            gateButton1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            gateButton1.transform.localScale = new Vector3(2.5f, 0.5f, 1f);
            gateButton1.transform.Find("Button").gameObject.GetComponent<ButtonObj>().type = "attack";
            gateButton1.transform.Find("Button").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0769f, 0.7642f, 0.0936f, 1f);
            GameObject gateButton2 = Object.Instantiate(gateButton1, gate.transform);
            gateButton2.name = "Button (1)";
            gateButton2.transform.localPosition = new Vector3(0.25f, 5f, 0f);
            gateButton2.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            GameObject gateSpike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            GameObject gateSpike2 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            GameObject gateSpike3 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            GameObject gateSpike4 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            GameObject gateSpike5 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            GameObject gateSpike6 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), gate.transform.Find("Door"));
            gateSpike1.transform.localPosition = new Vector3(-1.4f, -1.6f, 0f);
            gateSpike2.transform.localPosition = new Vector3(-1.4f, -1f, 0f);
            gateSpike3.transform.localPosition = new Vector3(-1.4f, -0.4f, 0f);
            gateSpike4.transform.localPosition = new Vector3(-1.4f, 0.2f, 0f);
            gateSpike5.transform.localPosition = new Vector3(-1.4f, 0.8f, 0f);
            gateSpike6.transform.localPosition = new Vector3(-1.4f, 1.4f, 0f);
            gateSpike1.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike2.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike3.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike4.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike5.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike6.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike1.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike2.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike3.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike4.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike5.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike6.transform.localScale = new Vector3(1f, 0.5f, 1f);
            gateSpike1.name = "Magic Spike";
            gateSpike2.name = "Magic Spike (1)";
            gateSpike3.name = "Magic Spike (2)";
            gateSpike4.name = "Magic Spike (3)";
            gateSpike5.name = "Magic Spike (4)";
            gateSpike6.name = "Magic Spike (5)";
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(0f, -2.1f, 0f);
            respawnPoint.name = "RespawnPoint";
            GameObject BouncePad = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Bounce Box - V"), roomReference.transform);
            BouncePad.name = "Bounce Pad";
            BouncePad.transform.localPosition = new Vector3(-4f, 6.5f, 0f);
            BouncePad.transform.localScale = new Vector3(2f, 0.4f, 1f);
            spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, false);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike2 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike3 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike4 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike5 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike6 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            GameObject spike7 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            spike1.transform.localPosition = new Vector3(-11.35f, 6.3f, 0f);
            spike2.transform.localPosition = new Vector3(-11.35f, 7.5f, 0f);
            spike3.transform.localPosition = new Vector3(-11.35f, 8.7f, 0f);
            spike4.transform.localPosition = new Vector3(-11.35f, 9.9f, 0f);
            spike5.transform.localPosition = new Vector3(-11.35f, 11.1f, 0f);
            spike6.transform.localPosition = new Vector3(-11.35f, 12.3f, 0f);
            spike7.transform.localPosition = new Vector3(2.7f, 2.8f, 0f);
            spike1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike3.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike4.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike5.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike6.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            spike7.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            spike1.name = "Magic Spike";
            spike2.name = "Magic Spike (1)";
            spike3.name = "Magic Spike (2)";
            spike4.name = "Magic Spike (3)";
            spike5.name = "Magic Spike (4)";
            spike6.name = "Magic Spike (5)";
            spike7.name = "Magic Spike (6)";
        }

        private static GameObject roomReference;
        private static GameObject spikeParent;
    }
}