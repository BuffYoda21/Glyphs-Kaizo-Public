using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.defense {
    public class TheNuke : MonoBehaviour
    {
        public void Start()
        {
            MelonLogger.Msg("[TheNuke] Nuke initialized");
        }

        public void RegisterTargets()
        {
            MelonLogger.Msg("[TheNuke] Registering targets");
            ANTICHEAT = GameObject.Find("ANTICHEAT-------------------------");
            loc = GameObject.Find("World/Region2/Sector 2/loc");
            loc1 = GameObject.Find("World/Region1/(R2B)(Map)/loc (1)");
            loc2 = GameObject.Find("World/AmbientDummy/loc (5)");                   //for some reason there are two 5s but no 2?
            loc3 = GameObject.Find("World/Region2/BackGroundDark /loc (3)");
            loc4 = GameObject.Find("World/AmbientDummy/loc (4)");
            loc5 = GameObject.Find("World/Region2/Sector 2/(R6-F)(Button2)/loc (5)");
            help = GameObject.Find("World/Region3/Green/(R7A)>(R5A)/Spikes/help");
            J = help.GetComponent<The>().j;
            if (ANTICHEAT == null || loc == null || loc1 == null || loc2 == null || loc3 == null || loc4 == null || loc5 == null || help == null || (J == null && !followUp))   //J does not return until the app is restarted
            {
                MelonLogger.Error("[TheNuke] Arming failed: One or more targets not found.");
                MelonLogger.Error("[TheNuke] " + $"ANTICHEAT: {ANTICHEAT != null}, loc: {loc != null}, loc1: {loc1 != null}, loc2: {loc2 != null}, loc3: {loc3 != null}, loc4: {loc4 != null}, loc5: {loc5 != null}, help: {help != null}, J: {J != null}");
            }
            else
            {
                MelonLogger.Msg("[TheNuke] All targets registered successfully.");
                if (testBuild)
                {
                    MelonLogger.Msg("[TheNuke] The nuke has been disabled for this test build.");
                    MelonLogger.Msg("[TheNuke] Disarming...");
                    return;
                }
                MelonLogger.Msg("[TheNuke] ARMED");
                armed = true;
            }
        }

        public void Update()
        {
            if (armed)
            {
                MelonLogger.Msg("[TheNuke] Destroying targets...");
                Explode();
            }
        }

        public void Explode()
        {
            if (J != null) DestroyImmediate(J);
            DestroyImmediate(ANTICHEAT);
            DestroyImmediate(help);
            DestroyImmediate(loc);
            DestroyImmediate(loc1);
            DestroyImmediate(loc2);
            DestroyImmediate(loc3);
            DestroyImmediate(loc4);
            DestroyImmediate(loc5);
            MelonLogger.Msg("[TheNuke] All targets destroyed.");
            armed = false;
            followUp = true;
        }

        private static bool armed = false;
        private static bool followUp = false;
        private static readonly bool testBuild = false;

        //target list
        private static GameObject ANTICHEAT;
        private static GameObject loc;
        private static GameObject loc1;
        private static GameObject loc2;
        private static GameObject loc3;
        private static GameObject loc4;
        private static GameObject loc5;
        private static GameObject help;
        private static GameObject J;
    }
}