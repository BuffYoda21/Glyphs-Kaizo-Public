using UnityEngine;

namespace GlyphsKaizo.Scripts {
    public static class Utils {
        // copies the GameObject passed in the number of times specified in a linear pattern
        public static void Pattern(GameObject org, axis a, int instances, int spacing, int rotation) {
            if (!org || instances <= 1) return;
            for (int i = 1; i < instances; i++) {
                switch (a) {
                    case axis.X:
                        Object.Instantiate(
                            org,
                            new Vector3(
                                org.transform.localPosition.x + spacing,
                                org.transform.localPosition.y,
                                org.transform.localPosition.z
                            ),
                            Quaternion.Euler(
                                org.transform.localRotation.x,
                                org.transform.localRotation.y,
                                org.transform.localRotation.z + rotation
                            ),
                            org.transform.parent
                        );
                    break;
                    case axis.Y:
                        Object.Instantiate(
                            org,
                            new Vector3(
                                org.transform.localPosition.x,
                                org.transform.localPosition.y + spacing,
                                org.transform.localPosition.z
                            ),
                            Quaternion.Euler(
                                org.transform.localRotation.x,
                                org.transform.localRotation.y,
                                org.transform.localRotation.z + rotation
                            ),
                            org.transform.parent
                        );
                    break;
                }
            }
        }

        public static void Pattern(GameObject org, axis a, int instances, int spacing) {
            Pattern(org, a, instances, spacing, 0);
        }

        public enum axis {
            X,
            Y
        }
    }
}