//This file is a dummy. It contains no logic and only serves the purpose to allow building of the mod without the actual logic.
//The original file contains code directly decompiled from Glyphs which is why this file is necessary
[RegisterTypeInIl2Cpp]
public class KaizoFlyingEnemy : MonoBehaviour {
    // Token: 0x060000B5 RID: 181 RVA: 0x00010892 File Offset: 0x0000EA92
    private void CacheReferences() {
        this.player = GameObject.Find("Player")?.GetComponent<PlayerController>();
        this.rb = base.GetComponent<Rigidbody2D>();
        this.ebase = base.GetComponent<EnemyBase>();
        this.dashAttackBlades = Object.Instantiate(Resources.Load<GameObject>("prefabs/game/DashAttackBlades"), base.transform.position, Quaternion.identity);
        this.dashAttackBlades.transform.parent = base.transform;
        AttackBox hitbox = dashAttackBlades.GetComponent<AttackBox>();
        hitbox.attackType = "enemy";
        hitbox.damage = 12;
        hitbox.multihit = true;
        dashAttackBlades.GetComponent<ParticleSpawner>().particle.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.4f);
        this.dashAttackBlades.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        this.dashAttackBlades.SetActive(false);
        this.attacktimer = Time.time + this.attackCD;
    }

    // Token: 0x060000B6 RID: 182 RVA: 0x000108CC File Offset: 0x0000EACC
    private void Update()
    {
    }

    // Token: 0x040001C2 RID: 450
    public float detectionDist = 10f;

    // Token: 0x040001C3 RID: 451
    public float moveSpeed = 4.5f;

    // Token: 0x040001C4 RID: 452
    public float attackCD = 5.5f;

    // Token: 0x040001C5 RID: 453
    public float attacktimer;

    // Token: 0x040001C6 RID: 454
    public int dir;

    // Token: 0x040001C7 RID: 455
    public bool detectedPlayer;

    // Token: 0x040001C8 RID: 456
    public bool attacking;

    // Token: 0x040001C9 RID: 457
    public bool flyoff;

    // Token: 0x040001CA RID: 458
    public Vector3 target;

    // Token: 0x040001CB RID: 459
    public PlayerController player;

    // Token: 0x040001CC RID: 460
    public Rigidbody2D rb;

    // Token: 0x040001CD RID: 461
    public EnemyBase ebase;

    public GameObject dashAttackBlades;
}
