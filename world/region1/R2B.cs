using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1 {
    public class R2B
    {
        public static void Load(GameObject regionReference, KaizoWorldManager worldManager)
        {
            roomReference = regionReference.transform.Find("(R2B)(Map)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R2B Room Reference not found!");
                return;
            }
            dashOrb = Object.Instantiate(worldManager.dashOrb, roomReference.transform);
            dashOrb.transform.localPosition = new Vector3(-4.5f, 2.8f, 0f);
            dashOrb.SetActive(true);
            roomReference.transform.Find("Tiles/Door (5)").gameObject.SetActive(false);
            GameObject button2 = Object.Instantiate(roomReference.transform.Find("Button (1)").gameObject, roomReference.transform);
            button2.name = "Button (2)";
            button2.transform.localPosition = new Vector3(-10.75f, -2.25f, 0f);
            button2.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
            button2.transform.Find("Button").GetComponent<ButtonObj>().type = "dash";
            button2.transform.Find("Button").GetComponent<SpriteRenderer>().color = new Color(0f, 0.6059f, 1f, 1f);
            //need to add logic and a custom save system to handle the dash orb
            //wait nvm maybe it just works? more testing needed
        }

        private static GameObject roomReference;
        private static GameObject dashOrb;
    }
}