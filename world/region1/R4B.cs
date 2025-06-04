using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public class R4B
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R4B)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R4B Room Reference not found!");
                return;
            }
            GameObject bouncePad = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Bounce Box - V"), roomReference.transform);
            bouncePad.transform.localPosition = new Vector3(0f, -6.5f, 0f);
            bouncePad.transform.localScale = new Vector3(3f, 0.5f, 1f);
            bouncePad.name = "BouncePad";
            bouncePad.GetComponent<BouncePlatform>().ystrength = 1.5f;
        }

        private static GameObject roomReference;
    }
}