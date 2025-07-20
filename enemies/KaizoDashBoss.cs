//This file is a dummy. It contains no logic and only serves the purpose to allow building of the mod without the actual logic.
//The original file contains code directly decompiled from Glyphs which is why this file is necessary
using MelonLoader;
using UnityEngine;
using Il2Cpp;
using UnityEngine.Events;

[RegisterTypeInIl2Cpp]
public class KaizoDashBoss : MonoBehaviour {
    // Token: 0x06000095 RID: 149 RVA: 0x0000D068 File Offset: 0x0000B268
    private void Start() {
        
    }

    // Token: 0x06000096 RID: 150 RVA: 0x0000D118 File Offset: 0x0000B318
    private void Update() {
        
    }

    // Token: 0x06000097 RID: 151 RVA: 0x0000D8CC File Offset: 0x0000BACC
    public void CameraShake(float duration) {
        
    }

    // Token: 0x06000098 RID: 152 RVA: 0x0000D8E8 File Offset: 0x0000BAE8
    private void FixedUpdate() {
        
    }

    // Token: 0x04000159 RID: 345
    public float dashtimer;

    // Token: 0x0400015A RID: 346
    public float dashpause = 5f;

    // Token: 0x0400015B RID: 347
    public float attackTime;

    // Token: 0x0400015C RID: 348
    public float orbspeed = 1f;

    // Token: 0x0400015D RID: 349
    public float cameraShakeEndtime;

    // Token: 0x0400015E RID: 350
    private float yposstart;

    // Token: 0x0400015F RID: 351
    private float xposstart;

    // Token: 0x04000160 RID: 352
    public int moveVert;

    // Token: 0x04000161 RID: 353
    public int moveHoriz;

    // Token: 0x04000162 RID: 354
    public int dashes = 3;

    // Token: 0x04000163 RID: 355
    public int phase;

    // Token: 0x04000164 RID: 356
    public bool dashing;

    // Token: 0x04000165 RID: 357
    public bool specialattack;

    // Token: 0x04000166 RID: 358
    public PlayerController player;

    // Token: 0x04000167 RID: 359
    private Rigidbody2D rb;

    // Token: 0x04000168 RID: 360
    private EnemyBase ebase;

    // Token: 0x04000169 RID: 361
    public GameObject orbparent;

    // Token: 0x0400016A RID: 362
    public GameObject spike;

    // Token: 0x0400016B RID: 363
    public DashBossAttackOrb[] orbs;

    // Token: 0x0400016C RID: 364
    public Vector3 destinationp;

    // Token: 0x0400016D RID: 365
    private Hover h;

    // Token: 0x0400016E RID: 366
    private GameCanvasManager gm;

    // Token: 0x0400016F RID: 367
    private BossBarManager bb;

    // Token: 0x04000170 RID: 368
    private Boss boss;

    // Token: 0x04000171 RID: 369
    public UnityEvent onPhase3;

    // Token: 0x04000172 RID: 370
    private Hover camHover;
}
