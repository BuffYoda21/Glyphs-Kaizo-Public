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
            gate.transform.Find("Door").localRotation = Quaternion.Euler(0f, 0f, 160f);
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
            gateSpike1.name = "Magic Spike";
            gateSpike2.name = "Magic Spike (1)";
            gateSpike3.name = "Magic Spike (2)";
            gateSpike4.name = "Magic Spike (3)";
            gateSpike5.name = "Magic Spike (4)";
            gateSpike6.name = "Magic Spike (5)";
            gateSpike1.transform.localPosition = new Vector3(-1.4f, 0f, 0f);
            gateSpike1.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            gateSpike1.transform.localScale = new Vector3(1f, 0.5f, 1f);
            //make other spikes like this but lined up on the top of the door

            //placeholder objects for modifications later
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(0f, 0f, 0f);
            respawnPoint.name = "RespawnPoint";
            spikeParent = new GameObject("Spikes");
            spikeParent.transform.SetParent(roomReference.transform, false);
            GameObject spike1 = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), spikeParent.transform);
            spike1.name = "Magic Spike";
            spike1.transform.localPosition = new Vector3(0f, 0f, 0f);
            spike1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }

        private static GameObject roomReference;
        private static GameObject spikeParent;
    }
}