using UnityEngine;
using MelonLoader;
namespace GlyphsKaizo.defense
{
    public class TheWatch : MonoBehaviour
    {
        public void Start()
        {
            MelonLogger.Msg("The watch is here");
        }

        public void Update()
        {
            GameObject helpObject = GameObject.Find("World/Region3/Green/(R7A)>(R5A)/Spikes/help");
            if (helpObject != null && helpObject.activeInHierarchy && !threatNeautralized)
            {
                MelonLogger.Warning("THE POLICE ARE AFTER YOU RUN!");
                MelonLogger.Msg("Buying you time, sending threat to deep space...");
                helpObject.transform.position = new Vector3(1000000000f, 0f, 0f);
                MelonLogger.Msg("Enabiling defensive measures... Oh wait there are none");
                MelonLogger.Msg("Getting rid of that obnoxious noise...");
                helpObject.GetComponent<AudioSource>().enabled = false;
                MelonLogger.Warning("If you are seeing this, the anti-cheat system for glyphs has been tripped somehow.\n" +
                                    "The game will crash if you attempt to change scenes (any cutscene or return to title).\n" +
                                    "My recomendation is find a place to save and restart Glyphs.\n" +
                                    "Please report this to the devs of Glyphs Kaizo along with the cooresponding log file.");
                threatNeautralized = true;
            }
        }

        private bool threatNeautralized = false;
    }
}
