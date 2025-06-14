using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GlyphsKaizo.Scripts.Puzzles
{
    public class Frag1 : MonoBehaviour
    {
        public void Start()
        {
            roomReference = GameObject.Find("World/Region1/(R0B) (Fragment1)");
            if (roomReference == null)
            {
                MelonLogger.Error("R0B Room Reference not found!");
                DestroyImmediate(this);
                return;
            }
            frag1 = roomReference.transform.Find("Fragment 1").gameObject;
            if (frag1 == null)
            {
                MelonLogger.Warning("Fragment 1 could not be found. This could be because the puzzle is already solved or an incorrect reference.");
                DestroyImmediate(this);
                return;
            }
            button = roomReference.transform.Find("FragButton/Button").gameObject.GetComponents<BoxCollider2D>()[1];
            frag1.SetActive(false);
            player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            pc = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        public void OnButtonPress()
        {
            MelonLogger.Msg("Button Pressed");
            triggered = true;
            frag1.SetActive(true);
            pc.mapDisabled = true;
            explosion = Object.Instantiate(Resources.Load<GameObject>("prefabs/particles/Explosion Ring"), frag1.transform);
            explosion.transform.localPosition = new Vector3(0f, 0f, 0f);
            MelonCoroutines.Start(ButtonTimer());
        }

        private System.Collections.IEnumerator ButtonTimer()
        {
            yield return new WaitForSeconds(60f);
            OnButtonUnpress();
        }

        public void OnButtonUnpress()
        {
            triggered = false;
            frag1.SetActive(false);
            pc.mapDisabled = false;
        }

        public void Update()
        {
            if (player.bounds.Intersects(button.bounds) && !triggered && frag1 != null)
                OnButtonPress();
        }

        public GameObject roomReference;
        public BoxCollider2D button;
        public GameObject frag1;
        public BoxCollider2D player;
        public PlayerController pc;
        public GameObject explosion;
        private bool triggered = false;
    }
}