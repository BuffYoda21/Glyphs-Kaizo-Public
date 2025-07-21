//This file is a dummy. It contains no logic and only serves the purpose to allow building of the mod without the actual logic.
//The original file contains code directly decompiled from Glyphs which is why this file is necessary
using UnityEngine;
using Il2Cpp;

public class KaizoAttackOrb : MonoBehaviour {
    // Token: 0x0600009A RID: 154 RVA: 0x0000DC14 File Offset: 0x0000BE14
    public void init() {

    }

    // Token: 0x0600009B RID: 155 RVA: 0x0000DC64 File Offset: 0x0000BE64
    private void FixedUpdate() {
        
    }

    // Token: 0x0600009C RID: 156 RVA: 0x0000E074 File Offset: 0x0000C274
    public void FlyTo(Vector3 pos, int a, float s) {

    }

    // Token: 0x0600009D RID: 157 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
    public void callBack() {

    }

    // Token: 0x04000173 RID: 371
    public Transform orbparent;

    // Token: 0x04000174 RID: 372
    public Vector3 destination;

    // Token: 0x04000175 RID: 373
    public Vector3 oglocalpos;

    // Token: 0x04000176 RID: 374
    public bool moving;

    // Token: 0x04000177 RID: 375
    public int attacknum;

    // Token: 0x04000178 RID: 376
    public int combonum;

    // Token: 0x04000179 RID: 377
    public float attackTime;

    // Token: 0x0400017A RID: 378
    public float speed = 3f;

    // Token: 0x0400017B RID: 379
    public KaizoDashBoss db;

    // Token: 0x0400017C RID: 380
    private WizardBoss wb;
}
