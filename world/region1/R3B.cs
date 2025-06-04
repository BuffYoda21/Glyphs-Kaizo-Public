using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.World.Region1
{
    public static class R3B
    {
        public static void Load(GameObject regionReference)
        {
            roomReference = regionReference.transform.Find("(R3B)").gameObject;
            if (roomReference == null)
            {
                MelonLogger.Error("R3B Room Reference not found!");
                return;
            }
            GameObject respawnPoint = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/RespawnPoint"), roomReference.transform);
            respawnPoint.transform.localPosition = new Vector3(8f, -3.4f, 0f);
            respawnPoint.name = "RespawnPoint";
            GameObject rubble = Object.Instantiate(GameObject.Find("World/Region2/Sector 3/(R4C)/Tiles/Disappearonsave/Rubble"), roomReference.transform);
            rubble.name = "Rubble";
            rubble.transform.localPosition = new Vector3(41f, -6.5f, 0f);
            rubble.SetActive(true);
            // add logic to clear a path through the rubble if construct is defeated
            GameObject slidingPlatform = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Platform"), roomReference.transform);
            slidingPlatform.name = "SlidingPlatform";
            slidingPlatform.transform.localPosition = new Vector3(-7f, 0f, 0f);
            slidingPlatform.GetComponent<SpriteRenderer>().color = new Color(0.502f, 0.502f, 0.502f, 1f);
            slidingPlatform.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            slidingPlatform.transform.localScale = new Vector3(.3f, 0.65f, 1f);
            slidingPlatform.GetComponent<SlidingPlatform>().xv = 0f;
            slidingPlatform.GetComponent<SlidingPlatform>().yv = 1f;
            slidingPlatform.GetComponent<SlidingPlatform>().speed = 2f;
            GameObject spike = Object.Instantiate(Resources.Load<GameObject>("prefabs/platforming/Magic Spike"), slidingPlatform.transform);
            spike.transform.localPosition = new Vector3(5.7f, 0f, 0f);
            spike.transform.localScale = new Vector3(2.7f, 1.2f, 0f);
            spike.name = "Magic Spike";
        }

        private static GameObject roomReference;
    }
}