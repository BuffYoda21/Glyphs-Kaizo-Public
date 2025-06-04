using GlyphsKaizo.defense;
using MelonLoader;
using UnityEngine;

namespace GlyphsKaizo.World {
    public class KaizoWorldManager : MonoBehaviour {
        //Collects item references for later use for the individual rooms. Probably going to move these Oob and deactiate and just make clones to place around.
        public void CacheItems() {
            sword = GameObject.Find("World/Region1/(R3D)(sword)/Sword");
            dashOrb = GameObject.Find("World/Region1/Runic Construct(R3E)/Dash Orb");
            map = GameObject.Find("World/Region1/(R2B)(Map)/Map");
            grapple = GameObject.Find("World/Region2/(R10A) (Boss2)/Grapple Worm");
            dashAttackOrb = GameObject.Find("World/Region2/Sector 2/(R11-E)>(R20-E)  (Shadow Rush)/Dash Attack Orb");
            parry = GameObject.Find("World/Region2/Sector 3/(R1E) (Parry)/Parry");
            //Temporary debug message for development purposes
            MelonLogger.Msg("[KaizoWorldManager] Item cache status: " +
                            $"Sword: {(sword != null ? "Found" : "Not Found")}, " +
                            $"Dash Orb: {(dashOrb != null ? "Found" : "Not Found")}, " +
                            $"Map: {(map != null ? "Found" : "Not Found")}, " +
                            $"Grapple: {(grapple != null ? "Found" : "Not Found")}, " +
                            $"Dash Attack Orb: {(dashAttackOrb != null ? "Found" : "Not Found")}, " +
                            $"Parry: {(parry != null ? "Found" : "Not Found")}");
            if (sword != null) {
                sword.transform.position = new Vector3(0, 0, 0);
                sword.SetActive(false);
            }
            if (dashOrb != null) {
                dashOrb.transform.position = new Vector3(0, 0, 0);
                dashOrb.SetActive(false);
            }
            if (map != null) {
                map.transform.position = new Vector3(0, 0, 0);
                map.SetActive(false);
            }
            if (grapple != null) {
                grapple.transform.position = new Vector3(0, 0, 0);
                grapple.SetActive(false);
            }
            if (dashAttackOrb != null) {
                dashAttackOrb.transform.position = new Vector3(0, 0, 0);
                dashAttackOrb.SetActive(false);
            }
            if (parry != null) {
                parry.transform.position = new Vector3(0, 0, 0);
                parry.SetActive(false);
            }
        }

        //items
        public GameObject sword;
        public GameObject dashOrb;
        public GameObject map;
        public GameObject grapple;
        public GameObject dashAttackOrb;
        public GameObject parry;

    }
}