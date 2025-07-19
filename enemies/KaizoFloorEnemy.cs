//This file is a dummy. It contains no logic and only serves the purpose to allow building of the mod without the actual logic.
//The original file contains code directly decompiled from Glyphs which is why this file is necessary
[RegisterTypeInIl2Cpp]
public class KaizoFloorEnemy : MonoBehaviour {
    // Token: 0x060000AB RID: 171 RVA: 0x0000E978 File Offset: 0x0000CB78
    private void CacheReferences() {
        this.player = GameObject.Find("Player")?.GetComponent<PlayerController>();
        this.rb = base.GetComponent<Rigidbody2D>();
        this.ebase = base.GetComponent<EnemyBase>();
    }

    // Token: 0x060000AC RID: 172 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
    public void FixedUpdate()
    {
    }

    // Token: 0x040001A0 RID: 416
    public float detectionDist = 10f;

    // Token: 0x040001A1 RID: 417
    public float moveSpeed = 4f;

    // Token: 0x040001A2 RID: 418
    public float moveCD;

    // Token: 0x040001A3 RID: 419
    public float attackCD;

    // Token: 0x040001A4 RID: 420
    public bool detectedPlayer;

    // Token: 0x040001A5 RID: 421
    public string facing = "right";

    // Token: 0x040001A6 RID: 422
    public PlayerController player;

    // Token: 0x040001A7 RID: 423
    public Rigidbody2D rb;

    // Token: 0x040001A8 RID: 424
    public EnemyBase ebase;
}
