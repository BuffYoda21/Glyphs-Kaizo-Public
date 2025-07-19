//This file is a dummy. It contains no logic and only serves the purpose to allow building of the mod without the actual logic.
//The original file contains code directly decompiled from Glyphs which is why this file is necessary
[RegisterTypeInIl2Cpp]
public class KaizoSpearBoss : MonoBehaviour
{
	// Token: 0x060000D6 RID: 214 RVA: 0x000123D0 File Offset: 0x000105D0
	private void Start()
	{
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00012500 File Offset: 0x00010700
	public void FixedUpdate()
  {
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0001465C File Offset: 0x0001285C
	public void CameraShake(float duration)
	{
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00014678 File Offset: 0x00012878
	public void lungeAtPlayer(Vector2 dir)
	{
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00014702 File Offset: 0x00012902
	public void ActivateSpear()
	{
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00014740 File Offset: 0x00012940
	public void DeactivateSpear()
	{
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00014794 File Offset: 0x00012994
	public void ActivateShield()
	{
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0001487C File Offset: 0x00012A7C
	public void BreakShield()
	{
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000148E4 File Offset: 0x00012AE4
	public void spawnSpears(int amount)
	{
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00014A9C File Offset: 0x00012C9C
	public void LaunchPlayer(Vector2 dir)
	{
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00014AF8 File Offset: 0x00012CF8
	public void PoiseBreak()
	{
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00014CE8 File Offset: 0x00012EE8
	public void StartAtPhase3()
	{
	}




	private GameObject GetSpearParent() {
		return this.gameObject.transform.Find("SpearRotate").gameObject;
	}

	private GameObject GetSpear() {
		return GetSpearParent().transform.Find("Spear").gameObject;
	}

	private ParticleSpawner GetSpearPS() {
		return this.GetSpear().GetComponent<ParticleSpawner>();
	}

	private SpriteRenderer GetSpearSR() {
		return this.GetSpear().GetComponent<SpriteRenderer>();
	}

	private EnemyBase GeteBase() {
		return this.gameObject.GetComponent<EnemyBase>();
	}

	private GameObject GetPlayer() {
		return originalBoss.GetComponent<KaizoSpearBoss>().player.gameObject;
	}

	// Token: 0x040001FE RID: 510
	//[Header("Stats")]
	public bool onGuard = true;

	// Token: 0x040001FF RID: 511
	//[Header("Stats")]
	public bool closeToPlayer;

	// Token: 0x04000200 RID: 512
	//[Header("Stats")]
	public bool spearCanDamage;

	// Token: 0x04000201 RID: 513
	//[Header("Stats")]
	public bool advancing;

	// Token: 0x04000202 RID: 514
	//[Header("Stats")]
	public bool lockrotation;

	// Token: 0x04000203 RID: 515
	//[Header("Stats")]
	public bool vulnerable;

	// Token: 0x04000204 RID: 516
	//[Header("Stats")]
	public bool rainAttackDue;

	// Token: 0x04000205 RID: 517
	//[Header("Stats")]
	public bool screenshakeinitiated;

	// Token: 0x04000206 RID: 518
	//[Header("Stats")]
	public bool nohitreset = true;

	// Token: 0x04000207 RID: 519
	public float attackRadius = 2f;

	// Token: 0x04000208 RID: 520
	public float closeRadius = 6f;

	// Token: 0x04000209 RID: 521
	public float spinTimer = -1f;

	// Token: 0x0400020A RID: 522
	public float damageTimer = -1f;

	// Token: 0x0400020B RID: 523
	public float attackCD;

	// Token: 0x0400020C RID: 524
	public float movementSpeed = 1.5f;

	// Token: 0x0400020D RID: 525
	public float spearMoveSpeed = 1f;

	// Token: 0x0400020E RID: 526
	public float vulnerableTimer = -1f;

	// Token: 0x0400020F RID: 527
	public float shieldBrokenTimer = -1f;

	// Token: 0x04000210 RID: 528
	public float lastplayerhp;

	// Token: 0x04000211 RID: 529
	public float attackSegmentTimer = -1f;

	// Token: 0x04000212 RID: 530
	public float spinSpeed = 1f;

	// Token: 0x04000213 RID: 531
	public float supremeRainCalls;

	// Token: 0x04000214 RID: 532
	public float cameraShakeEndtime;

	// Token: 0x04000215 RID: 533
	//[Header("Phase 2")]
	public float flightSpeed;

	// Token: 0x04000216 RID: 534
	public Vector3 flightTarget;

	// Token: 0x04000217 RID: 535
	//[Header("Battle Operation")]
	public int poise = 6;

	// Token: 0x04000218 RID: 536
	//[Header("Battle Operation")]
	public int attackID;

	// Token: 0x04000219 RID: 537
	//[Header("Battle Operation")]
	public int phase = 1;

	// Token: 0x0400021A RID: 538
	//[Header("Battle Operation")]
	public int ai = 1;

	// Token: 0x0400021B RID: 539
	//[Header("Battle Operation")]
	public int chainattacksleft;

	// Token: 0x0400021C RID: 540
	public float parryCD;                               //was private

	// Token: 0x0400021D RID: 541
	public PlayerController player;                     //was private

	// Token: 0x0400021E RID: 542
	public EnemyBase ebase;                             //was private

	// Token: 0x0400021F RID: 543
	//[Header("Object References")]
	public GameObject spear;

	// Token: 0x04000220 RID: 544
	//[Header("Object References")]
	public GameObject spearParent;

	// Token: 0x04000221 RID: 545
	public GameObject parryObject;

	// Token: 0x04000222 RID: 546
	public GameObject attackObject;

	// Token: 0x04000223 RID: 547
	public GameObject shieldObj;

	// Token: 0x04000224 RID: 548
	public GameObject shieldParticle;

	// Token: 0x04000225 RID: 549
	public GameObject shieldBreakParticle;

	// Token: 0x04000226 RID: 550
	public Color shieldColor;

	// Token: 0x04000227 RID: 551
	public Color vulnerableColor;

	// Token: 0x04000228 RID: 552
	public Vector2 spearTargetDir;

	// Token: 0x04000229 RID: 553
	public Vector2 spearTargetPos;

	// Token: 0x0400022A RID: 554
	public Vector2 battleOrigin;

	// Token: 0x0400022B RID: 555
	//[Header("Events")]
	public bool hasShieldBrokenYet;

	// Token: 0x0400022C RID: 556
	public UnityEvent showAura;

	// Token: 0x0400022D RID: 557
	public UnityEvent phase2;

	// Token: 0x0400022E RID: 558
	public UnityEvent phase3;

	// Token: 0x0400022F RID: 559
	public Rigidbody2D rb;                              //was private

	// Token: 0x04000230 RID: 560
	public SaveManager sm;                              //was private

	// Token: 0x04000231 RID: 561
	//[Header("Final")]
	public bool fillingHP;

	// Token: 0x04000232 RID: 562
	public GameObject phase3WingParticle;

	// Token: 0x04000233 RID: 563
	public GameObject phase3SpearParticle;

	// Token: 0x04000234 RID: 564
	public GameObject eyeParticle;

	// Token: 0x04000235 RID: 565
	public GameObject eyeObject;

	// Token: 0x04000236 RID: 566
	public GameObject eyeWarningParticle;

	// Token: 0x04000237 RID: 567
	public Color phase3WingColor;

	// Token: 0x04000238 RID: 568
	public Color phase3SpearColor;

	// Token: 0x04000239 RID: 569
	public Color phase3hpcolor;

	// Token: 0x0400023A RID: 570
	public Color phase3hpdelaycolor;

	// Token: 0x0400023B RID: 571
	public Color phase3hpbackcolor;

	// Token: 0x0400023C RID: 572
	public SpriteRenderer spearSR;

	// Token: 0x0400023D RID: 573
	public SpriteRenderer wingSR;

	// Token: 0x0400023E RID: 574
	public ParticleSpawner spearPS;

	// Token: 0x0400023F RID: 575
	public ParticleSpawner wingPS;

	// Token: 0x04000240 RID: 576
	public Hover camHover;                                      //was private

	// Token: 0x04000241 RID: 577
	public SpriteRenderer sr;                                   //was private

	// Token: 0x04000242 RID: 578
	public Boss boss;                                           //was private

	// Token: 0x04000243 RID: 579
	public Sprite phase3Sprite;

	// Token: 0x04000244 RID: 580
	public Sprite phase3Spear;

	public static bool cloned = false;

	public static GameObject cleanClone;

	public bool initialized = false;

	public static GameObject originalBoss;
}
