using UnityEngine;
using MelonLoader;

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
            sword = Object.Instantiate(worldManager.sword, roomReference.transform);
            sword.transform.localPosition = new Vector3(-4.5f, 2.8f, 0f);
            //todo: Delete door on right, move button to the right and turn into green button,
            //      possibly instead turn original button into blue button and clone it and move
            //      the clone to the right and turn it into a green button.
            //      Might also need to add a platform to the right so players can get back up without dash.
        }

        private static GameObject roomReference;
        private static GameObject sword;
    }
}