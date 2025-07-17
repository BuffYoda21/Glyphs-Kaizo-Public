using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace GlyphsKaizo.Scripts {
    public static class Utils {
        // copies the GameObject passed in the number of times specified in a linear pattern
        public static List<GameObject> Pattern(GameObject org, axis a, int instances, int spacing, int rotation) {
            if (!org || instances <= 1) return null;
            List<GameObject> output = new List<GameObject>();
            output.Add(org);
            for (int i = 1; i < instances; i++) {
                switch (a) {
                    case axis.X:
                        output.Add(Object.Instantiate(
                            org,
                            new Vector3(
                                org.transform.position.x + spacing,
                                org.transform.position.y,
                                org.transform.position.z
                            ),
                            Quaternion.Euler(
                                org.transform.localRotation.x,
                                org.transform.localRotation.y,
                                org.transform.localRotation.z + rotation
                            ),
                            org.transform.parent
                        ));
                        break;
                    case axis.Y:
                        output.Add(Object.Instantiate(
                            org,
                            new Vector3(
                                org.transform.position.x,
                                org.transform.position.y + spacing,
                                org.transform.position.z
                            ),
                            Quaternion.Euler(
                                org.transform.localRotation.x,
                                org.transform.localRotation.y,
                                org.transform.localRotation.z + rotation
                            ),
                            org.transform.parent
                        ));
                        break;
                }
            }
            return output;
        }

        public static List<GameObject> Pattern(GameObject org, axis a, int instances, int spacing) {
            return Pattern(org, a, instances, spacing, 0);
        }

        public enum axis {
            X,
            Y
        }
    }
}