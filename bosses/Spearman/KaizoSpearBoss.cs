using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityObject = UnityEngine.Object;
using UnityRandom = UnityEngine.Random;
using Il2Cpp;
using Il2CppSystem;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using GlyphsKaizo;

// Token: 0x0200002B RID: 43
[RegisterTypeInIl2Cpp]
public class KaizoSpearBoss : MonoBehaviour
{
	// Token: 0x060000D6 RID: 214 RVA: 0x000123D0 File Offset: 0x000105D0
	private void Start()
	{
		//Clones do not run this logic
		if (this.name != "Spearman") {
			return;
		}
		this.boss = base.GetComponent<Boss>();
		this.player = UnityObject.FindFirstObjectByType<PlayerController>();
		this.ebase = base.GetComponent<EnemyBase>();
		this.ebase.shieldDamageThreshold = 99;
		this.spearTargetDir = new Vector2(this.player.transform.position.x, this.player.transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
		this.spearParent = this.spear.transform.parent.gameObject;
		this.rb = base.GetComponent<Rigidbody2D>();
		this.shieldColor = this.shieldObj.GetComponent<SpriteRenderer>().color;
		this.sr = base.GetComponent<SpriteRenderer>();
		if (this.phase != 3)
		{
			this.ActivateShield();
		}
		this.battleOrigin = base.transform.position;
		this.sm = UnityObject.FindFirstObjectByType<SaveManager>();
		this.camHover = UnityObject.FindFirstObjectByType<CameraController>().transform.parent.GetComponent<Hover>();
		originalBoss = this.gameObject;
		cloned = false;
		initialized = true;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00012500 File Offset: 0x00010700
	public void FixedUpdate()
	{
		if (!this.initialized)
			return;
		if (this.camHover.enabled && Time.time > this.cameraShakeEndtime)
		{
			this.camHover.enabled = false;
		}
		if (!this.screenshakeinitiated && this.phase == 3)
		{
			UnityObject.FindFirstObjectByType<CameraController>().gameObject.transform.parent.GetComponent<Hover>().enabled = true;
			this.screenshakeinitiated = true;
		}
		this.GetSpear().transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		if (this.phase == 2 && this.GeteBase().hp < 2f)
		{
			this.ebase.hp = 1f;
			UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/Explosion"), new Vector2(base.transform.position.x, base.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
			Boss bossController = base.GetComponent<Boss>();
			bossController.StartDeath();
			this.phase = 3;
			this.ai = -1;
			this.ebase.shielded = true;
			this.attackCD = Time.time + 9.9f;
			bossController.StartDeath();
			Transform projectileManager = GameObject.Find("ProjectileManager").transform;
			for (int i = 0; i < projectileManager.childCount; i++)
			{
				Transform obj = projectileManager.GetChild(i);
				UnityObject.Destroy(obj.gameObject);
			}
			UnityObject.Destroy(GameObject.Find("Spearman(Clone)"));
		}
		if (this.phase == 4 && this.GeteBase().hp < 1f)
		{
			UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/Explosion"), new Vector2(base.transform.position.x, base.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
			this.phase = -99;
			this.ai = -99;
			if (this.player.currentNohit)
			{
				this.player.NohitComplete();
				sm.SaveBool("spearman-nohit");
			}
		}
		if (this.fillingHP)
		{
			if (Time.time > this.attackCD)
			{
				this.ebase.hp = Mathf.Lerp(this.ebase.hp, this.ebase.maxHp + 10f, Time.deltaTime / 2f);
			}
			if (this.ebase.hp >= this.ebase.maxHp)
			{
				this.fillingHP = false;
				this.ebase.shielded = false;
				this.attackCD = 3f;
				UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
				UnityObject.FindFirstObjectByType<CameraController>().gameObject.transform.parent.GetComponent<Hover>().enabled = false;
				this.ebase.overrideDeath = false;
			}
		}
		else if (this.phase == 3 && cleanClone == null)
		{
			cleanClone = UnityEngine.Object.Instantiate(this.gameObject, this.transform.position, Quaternion.identity);     //Stores a clone of a clean spearman AI
			cleanClone.SetActive(false);
		}
		else if (this.ai == 3)
		{
			if (this.GeteBase().hp < this.GeteBase().maxHp / 2f && this.phase == 3) //start phase 4
			{
				this.phase = 4;
				this.GeteBase().def = 3;
				movementSpeed = 6;
			}
			if (Time.time > this.attackCD)	//Start of Enlightened decision tree
			{
				this.rb.gravityScale = 1f;
				this.lockrotation = false;
				this.advancing = false;
				int num = this.attackID;
				if (this.chainattacksleft > 0)
				{
					this.chainattacksleft--;
				}
				else if (this.phase == 3 && UnityRandom.Range(1, 3) != 1) //Added additonal chance to trigger phase 4 attacks early
				{
					this.attackID = UnityRandom.Range(0, 5);
					if (this.attackID == num)
					{
						this.attackID++;
						if (this.attackID == 5)
						{
							this.attackID = 0;
						}
					}
					if (this.attackID == 2)
					{
						if (this.rainAttackDue)
						{
							this.rainAttackDue = false;
						}
						else
						{
							this.rainAttackDue = true;
							this.attackID = 1;
						}
					}
				}
				else if (this.phase >= 3)
				{
					this.attackID = UnityRandom.Range(0, 7);
					if (this.attackID == num)
					{
						this.attackID++;
						if (this.attackID == 7)
						{
							this.attackID = 6;
						}
					}
					if (this.attackID == 2 || this.attackID == 5)
					{
						if (this.rainAttackDue)
						{
							this.rainAttackDue = false;
						}
						else
						{
							this.rainAttackDue = true;
							this.attackID = 6;
						}
					}
					if (this.attackID == 6)
					{
						if (this.supremeRainCalls > 1f)
						{
							this.supremeRainCalls = 0f;
						}
						else
						{
							this.supremeRainCalls += 1f;
							this.attackID = 0;
						}
					}
					if (this.attackID != 4 && UnityRandom.Range(1, 7) == 1) //increase change for rush attack
						this.attackID = 4;
					if (this.attackID != 5 && UnityRandom.Range(1, 7) == 1) //increase change for horizontal spears
						this.attackID = 5;
					if ((UnityRandom.Range(1, 20) == 1 && phase == 3) || (UnityRandom.Range(1,15) == 1 && phase == 4)) //increase chance for supreme rain
						return; //supreme rain method call
				}
				switch (this.attackID)
				{
					case 0:
						EnlightenedSpinLunge(0);
						break;
					case 1:
						EnlightenedLunge(0);
						break;
					case 2:
						EnlightenedSpearRain(0);
						break;
					case 3:
						EnlightenedJump();
						break;
					case 4:
						EnlightenedChainAttackWarning();
						break;
					case 5:
						EnlightenedSummonHorizontalSpears();
						break;
					case 6:
						EnlightenedSupremeRainStart();
						break;
					case 10:
						EnlightenedChainAttack();
						break;
				}
			}
			if (Time.time > this.attackSegmentTimer && this.attackSegmentTimer != -1f)
			{
				this.attackSegmentTimer = -1f;
				int num2 = this.attackID;
				if (num2 != 3)
				{
					if (num2 == 6 || (UnityRandom.Range(1, 5) == 1 && phase == 4))
					{
						EnlightenedSupremeRain();
					}
				}
				else
				{
					EnlightenedJumpAttack();
				}
			}
			if (this.advancing)
			{
				if (this.GetPlayer().transform.position.x > base.transform.position.x)
				{
					this.rb.linearVelocity = new Vector2(this.movementSpeed, this.rb.linearVelocity.y);
				}
				else
				{
					this.rb.linearVelocity = new Vector2(-this.movementSpeed, this.rb.linearVelocity.y);
				}
				if (this.closeToPlayer)
				{
					this.advancing = false;
					switch (this.attackID)
					{
						case 0:
							EnlightenedSpinLunge(1);
							break;
						case 1:
							EnlightenedLunge(1);
							break;
						case 2:
							EnlightenedSpearRain(1);
							break;
					}
				}
			}
		}
		if (this.ai == -1 && Time.time > this.attackCD)
		{
			this.sm.InstantLoadScene(15, "SpearmanPhase3", true);
		}
		if (this.phase == 1 && this.ebase.hp < this.ebase.maxHp / 2f)
		{
			this.CameraShake(2f);
			this.phase = 2;
			this.poise = 5;
			this.attackCD = Time.time + 5f;
			this.flightSpeed = 1f;
			this.flightTarget = new Vector3(base.transform.position.x, base.transform.position.y + 10f, base.transform.position.z);
			this.rb.gravityScale = 0f;
			this.ai = 2;
			this.ebase.def = 3;
			this.phase2.Invoke();
			this.movementSpeed = 2.5f;
		}
		if (this.ai == 2)
		{
			this.damageTimer = -1f;
			this.spinTimer = -1f;
			this.attackSegmentTimer = -1f;
			base.transform.position = Vector2.Lerp(base.transform.position, this.flightTarget, Time.deltaTime * this.flightSpeed);
			if (Time.time > this.attackCD)
			{
				this.rb.gravityScale = 0f;
				this.rb.linearVelocity = new Vector2(0f, 0f);
				int num3 = this.attackID;
				this.attackID = UnityRandom.Range(0, 3);
				this.poise--;
				if (this.poise < 1)
				{
					this.ai = 1;
					this.poise = 3;
					this.rb.gravityScale = 4f;
					this.attackCD = Time.time + 8f;
				}
				if (this.attackID == num3)
				{
					this.attackID++;
					if (this.attackID == 3)
					{
						this.attackID = 0;
					}
				}
				if (this.attackID == 2)
				{
					if (this.rainAttackDue)
					{
						this.rainAttackDue = false;
					}
					else
					{
						this.rainAttackDue = true;
						this.attackID = 1;
					}
				}
				int num4;
				if (UnityRandom.Range(0, 2) == 0)
				{
					num4 = 1;
				}
				else
				{
					num4 = -1;
				}
				switch (this.attackID)
				{
					case 0:
						this.flightTarget = new Vector3(this.battleOrigin.x + (float)(14 * num4), this.battleOrigin.y + 10f, base.transform.position.z);
						this.flightSpeed = 2f;
						if (Vector2.Distance(base.transform.position, this.flightTarget) > 2f)
						{
							for (int m = 0; m < 10; m++)
							{
								GameObject gameObject6 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/RetargetSpearProjectile"), new Vector3(this.battleOrigin.x + (float)(14 * num4) + (float)(m * -2 * num4), this.battleOrigin.y + 10f, base.transform.position.z), Quaternion.identity);
								gameObject6.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
								gameObject6.GetComponent<Projectile>().bombdelay = 0.5f + (float)m * 0.25f;
							}
							this.attackCD = Time.time + 3f;
						}
						else
						{
							for (int n = 0; n < 10; n++)
							{
								GameObject gameObject7 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/RetargetSpearProjectile"), new Vector3(base.transform.position.x, this.battleOrigin.y + 10f, base.transform.position.z), Quaternion.identity);
								gameObject7.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
								gameObject7.GetComponent<Projectile>().bombdelay = 0.5f + (float)n * 0.25f;
							}
							this.attackCD = Time.time + 3f;
						}
						break;
					case 1:
						this.CameraShake(0.5f);
						this.flightTarget = new Vector3(this.battleOrigin.x + (float)(18 * num4), this.battleOrigin.y + 4f, base.transform.position.z);
						this.flightSpeed = 2f;
						for (int num5 = 0; num5 < 10; num5++)
						{
							GameObject gameObject8 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/HorizontalSpearProjectile"), new Vector3(this.battleOrigin.x + (float)(90 * num4), this.battleOrigin.y + (float)num5 * 2.5f, base.transform.position.z), Quaternion.identity);
							if (num4 == 1)
							{
								gameObject8.transform.Rotate(0f, 0f, 180f);
							}
							gameObject8.GetComponent<Projectile>().bombdelay = 1.5f;
						}
						this.attackCD = Time.time + 4f;
						break;
					case 2:
						this.flightTarget = new Vector3(this.battleOrigin.x, this.battleOrigin.y + 4f, base.transform.position.z);
						this.flightSpeed = 2f;
						this.spawnSpears(15);
						this.attackCD = Time.time + 4f;
						break;
				}
			}
		}
		else if (this.ai == 1)
		{
			if (this.phase == 1)
			{
				if (cleanClone == null)
				{
					cleanClone = UnityEngine.Object.Instantiate(this.gameObject, this.transform.position, Quaternion.identity);     //Stores a clone of a clean spearman AI
					cleanClone.SetActive(false);
				}
				if (this.ebase.shielded)
				{
					if (this.vulnerable && (Time.time > this.vulnerableTimer || this.lastplayerhp != this.player.hp))
					{
						this.ActivateShield();
					}
				}
				else if (Time.time > this.shieldBrokenTimer)
				{
					this.poise = UnityRandom.Range(4, 6);
					this.ActivateShield();
				}
				if (Time.time < this.shieldBrokenTimer)
				{
					this.attackCD = Time.time + 3f;
					this.lockrotation = false;
					this.spearTargetPos = new Vector2(0f, 0f);
					this.spearCanDamage = false;
					this.spearMoveSpeed = 1f;
					this.damageTimer = -1f;
					this.DeactivateSpear();
				}
			}
			if (Time.time > this.attackCD)
			{
				this.rb.gravityScale = 1f;
				this.lockrotation = false;
				this.advancing = false;
				int num6 = this.attackID;
				if (this.closeToPlayer)
				{
					this.poise--;
					if (this.phase == 2 && this.poise < 1)
					{
						this.ai = 2;
						this.poise = 5;
						this.attackCD = Time.time + 8f;
					}
				}
				if (this.poise < 1 && this.closeToPlayer && this.phase == 1)
				{
					this.PoiseBreak();
					if (this.attackID == 3)
					{
						this.attackID = 1;
					}
				}
				else
				{
					this.attackID = UnityRandom.Range(0, 4);
					if (this.attackID == num6)
					{
						this.attackID++;
						if (this.attackID == 4)
						{
							this.attackID = 0;
						}
					}
					if (this.attackID == 2)
					{
						if (this.rainAttackDue)
						{
							this.rainAttackDue = false;
						}
						else
						{
							this.rainAttackDue = true;
							this.attackID = 1;
						}
					}
				}
				switch (this.attackID)
				{
					case 0:
						if (this.closeToPlayer)
						{
							this.lungeAtPlayer(new Vector2(6f, 1.25f));
							this.spinTimer = Time.time + 0.75f;
							this.attackCD = Time.time + 3f;
						}
						else
						{
							this.advancing = true;
							this.attackCD = Time.time + 5f;
						}
						break;
					case 1:
						if (this.closeToPlayer)
						{
							this.spearMoveSpeed = 2f;
							this.spearTargetPos = new Vector2(1f, 0f);
							this.lungeAtPlayer(new Vector2(8f, 1f));
							this.damageTimer = Time.time + 0.6f;
							this.attackCD = Time.time + 3f;
						}
						else
						{
							this.advancing = true;
							this.spearTargetPos = new Vector2(-1f, 0.5f);
							this.attackCD = Time.time + 5f;
						}
						break;
					case 2:
						if (this.closeToPlayer)
						{
							this.spawnSpears(25);
							this.spearMoveSpeed = 2f;
							this.spearTargetPos = new Vector2(0f, 1.25f);
							UnityObject.Instantiate(this.shieldParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
							this.attackCD = Time.time + 3f;
						}
						else
						{
							this.spearMoveSpeed = 2f;
							this.lockrotation = true;
							this.spearTargetDir = Vector2.up;
							this.spearTargetPos = new Vector2(0f, 1.25f);
							this.advancing = true;
							this.attackCD = Time.time + 5f;
						}
						break;
					case 3:
						this.lungeAtPlayer(new Vector2(8f, 15f));
						this.spinTimer = Time.time + 2.1f;
						this.damageTimer = Time.time + 4f;
						this.attackSegmentTimer = Time.time + 2f;
						this.attackCD = Time.time + 4f;
						if (!this.closeToPlayer)
						{
							this.poise--;
						}
						break;
				}
			}
			if (Time.time > this.attackSegmentTimer && this.attackSegmentTimer != -1f)
			{
				this.attackSegmentTimer = -1f;
				if (this.attackID == 3)
				{
					this.rb.gravityScale = 2f;
					if (phase == 1)
					{
						//Triple burst
						Vector2 baseDir = (player.transform.position - transform.position).normalized;
						float[] angles = { -5f, 0f, 5f };

						foreach (float angle in angles)
						{
							GameObject proj = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/SlowSpearProjectile"), transform.position, Quaternion.identity);
							Vector2 rotatedDir = Quaternion.Euler(0, 0, angle) * baseDir;
							proj.transform.right = rotatedDir;
							proj.GetComponent<Projectile>().bombdelay = 0f;
						}
					}
					else
					{
						//base code
						GameObject gameObject9 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/SlowSpearProjectile"), base.transform.position, Quaternion.identity);
						gameObject9.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
						gameObject9.GetComponent<Projectile>().bombdelay = 0f;
					}
				}
			}
			if (this.advancing)
			{
				if (this.GetPlayer().transform.position.x > base.transform.position.x)
				{
					this.rb.linearVelocity = new Vector2(this.movementSpeed, this.rb.linearVelocity.y);
				}
				else
				{
					this.rb.linearVelocity = new Vector2(-this.movementSpeed, this.rb.linearVelocity.y);
				}
				if (this.closeToPlayer)
				{
					this.poise--;
					if (this.phase == 2 && this.poise < 1)
					{
						this.ai = 2;
						this.poise = 5;
						this.attackCD = Time.time + 8f;
					}
					if (this.poise < 1 && this.phase == 1)
					{
						this.PoiseBreak();
					}
					this.advancing = false;
					switch (this.attackID)
					{
						case 0:
							this.lungeAtPlayer(new Vector2(6f, 1f));
							this.spinTimer = Time.time + 0.6f;
							this.attackCD = Time.time + 3f;
							break;
						case 1:
							this.spearMoveSpeed = 4f;
							this.spearTargetPos = new Vector2(1f, 0f);
							this.lungeAtPlayer(new Vector2(8f, 1f));
							this.damageTimer = Time.time + 0.75f;
							this.attackCD = Time.time + 3.5f;
							break;
						case 2:
							this.spawnSpears(25);
							this.spearMoveSpeed = 2f;
							this.spearTargetPos = new Vector2(0f, 2f);
							this.attackCD = Time.time + 3.5f;
							UnityObject.Instantiate(this.shieldParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
							break;
					}
				}
			}
			if (Time.time > this.parryCD && !this.spearCanDamage && Time.time > this.shieldBrokenTimer && this.phase == 1 && Vector2.Distance(this.GetPlayer().transform.position, base.transform.position) < this.attackRadius)
			{
				GameObject gameObject10 = UnityObject.Instantiate(this.parryObject, base.transform.position, base.transform.rotation);
				gameObject10.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
				gameObject10.transform.parent = base.transform;
				this.GetSpearParent().transform.right = gameObject10.transform.right;
				this.GetSpearParent().transform.Rotate(0f, 0f, -15f);
				this.parryCD = Time.time + 0.5f;
				this.LaunchPlayer(new Vector2(gameObject10.transform.right.x * 15f, 3f));
			}
		}
		if (Time.time < this.spinTimer)
		{
			this.spearTargetPos = new Vector2(1.25f, 0f);
			this.GetSpearParent().transform.Rotate(0f, 0f, 12f * this.spinSpeed);
			this.damageTimer = Time.time + 0.1f;
		}
		else if (this.lockrotation)
		{
			this.GetSpearParent().transform.right = Vector2.Lerp(this.GetSpearParent().transform.right, this.spearTargetDir, Time.deltaTime);
		}
		else
		{
			this.GetSpearParent().transform.right = Vector2.Lerp(this.GetSpearParent().transform.right, new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y), Time.deltaTime);
		}
		if (Time.time < this.damageTimer)
		{
			if (!this.spearCanDamage)
			{
				this.ActivateSpear();
			}
		}
		else
		{
			if (this.spearCanDamage)
			{
				this.DeactivateSpear();
			}
			this.spearTargetPos = new Vector2(0f, 0f);
		}
		this.GetSpear().transform.localPosition = Vector2.Lerp(this.GetSpear().transform.localPosition, this.spearTargetPos, Time.deltaTime * this.spearMoveSpeed);
		if (Vector2.Distance(this.GetPlayer().transform.position, base.transform.position) < this.closeRadius)
		{
			this.closeToPlayer = true;
			return;
		}
		this.closeToPlayer = false;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0001465C File Offset: 0x0001285C
	public void CameraShake(float duration)
	{
		this.camHover.enabled = true;
		this.cameraShakeEndtime = Time.time + duration;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00014678 File Offset: 0x00012878
	public void lungeAtPlayer(Vector2 dir)
	{
		if (phase != 2)         //All lunges (excluding phase 2) are 50% more powerful
			dir.x *= 1.5f;
		if ((phase == 3 && UnityRandom.Range(1, 10) == 1) || (phase == 4 && UnityRandom.Range(1, 5) == 1))          //Enlightened has a 10% chance (20% for phase 4) to have another 50% power stacked on top of the already boosted stat
			dir.x *= 1.5f;
		this.rb.linearVelocity = new Vector2(0f, 0f);
		if (this.GetPlayer().transform.position.x > base.transform.position.x)
		{
			this.rb.AddForce(new Vector2(dir.x, dir.y), ForceMode2D.Impulse);
			return;
		}
		this.rb.AddForce(new Vector2(-dir.x, dir.y), ForceMode2D.Impulse);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00014702 File Offset: 0x00012902
	public void ActivateSpear()
	{
		this.spearCanDamage = true;
		this.GetSpear().GetComponent<AttackBox>().enabled = true;
		this.GetSpear().GetComponent<ParticleSpawner>().enabled = true;
		this.GetSpear().GetComponent<BoxCollider2D>().enabled = true;
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00014740 File Offset: 0x00012940
	public void DeactivateSpear()
	{
		this.spearCanDamage = false;
		this.GetSpear().GetComponent<AttackBox>().enabled = false;
		this.GetSpear().GetComponent<ParticleSpawner>().enabled = false;
		this.GetSpear().GetComponent<BoxCollider2D>().enabled = false;
		this.spearMoveSpeed = 0f;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00014794 File Offset: 0x00012994
	public void ActivateShield()
	{
		if (!this.ebase.shielded && this.closeToPlayer)
		{
			this.parryCD = Time.time + 1f;
			if (this.player.transform.position.x > base.transform.position.x)
			{
				this.LaunchPlayer(new Vector2(25f, 5f));
			}
			else
			{
				this.LaunchPlayer(new Vector2(-25f, 5f));
			}
		}
		this.shieldObj.SetActive(true);
		this.vulnerable = false;
		this.shieldObj.GetComponent<SpriteRenderer>().color = this.shieldColor;
		this.ebase.shielded = true;
		UnityObject.Instantiate(this.shieldParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0001487C File Offset: 0x00012A7C
	public void BreakShield()
	{
		this.DeactivateSpear();                 //can't damage you while stunned
		this.shieldObj.SetActive(false);
		this.ebase.shielded = false;
		UnityObject.Instantiate(this.shieldBreakParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
		this.vulnerable = false;
		this.shieldBrokenTimer = Time.time + 4f;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000148E4 File Offset: 0x00012AE4
	public void spawnSpears(int amount)
	{
		if (this.phase == 3 || this.phase == 4)
		{
			for (int i = 0; i < amount; i++)
			{
				GameObject gameObject = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkSpearProjectile"), this.GetPlayer().transform.position, Quaternion.identity);
				gameObject.transform.Translate((float)UnityRandom.Range(-15, 15), 0f, 0f);
				gameObject.transform.Rotate(0f, 0f, (float)UnityRandom.Range(-35, -125));
				gameObject.transform.position -= gameObject.transform.right * 100f;
				gameObject.GetComponent<Projectile>().bombdelay += 0.15f * (float)i;
			}
			return;
		}
		for (int j = 0; j < amount; j++)
		{
			GameObject gameObject2 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/SpearProjectile"), this.GetPlayer().transform.position, Quaternion.identity);
			gameObject2.transform.Translate((float)UnityRandom.Range(-15, 15), 0f, 0f);
			gameObject2.transform.Rotate(0f, 0f, (float)UnityRandom.Range(-35, -125));
			gameObject2.transform.position -= gameObject2.transform.right * 100f;
			gameObject2.GetComponent<Projectile>().bombdelay += 0.15f * (float)j;
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00014A9C File Offset: 0x00012C9C
	public void LaunchPlayer(Vector2 dir)
	{
		this.CameraShake(0.25f);
		this.GetPlayer().GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, 0f);
		this.GetPlayer().GetComponent<PlayerController>().dashtimer = 0f;
		this.GetPlayer().GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00014AF8 File Offset: 0x00012CF8
	public void PoiseBreak()
	{
		this.vulnerable = true;
		this.lastplayerhp = this.GetPlayer().GetComponent<PlayerController>().hp;
		this.shieldObj.GetComponent<SpriteRenderer>().color = this.vulnerableColor;
		//this.vulnerableTimer = Time.time + 1f;
		this.vulnerableTimer = Time.time + (this.ebase.hp / this.ebase.maxHp / 2);
		this.poise = UnityRandom.Range(3, 5);
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00014B51 File Offset: 0x00012D51
	private void LateUpdate()
	{
		//LateUpdate breaks clone ai for some reason
		if (this.nohitreset && this.name == "Spearman")
		{
			this.GetPlayer().GetComponent<PlayerController>().currentNohit = true;
			this.nohitreset = false;
		}
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00014B70 File Offset: 0x00012D70
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (this.phase == 1 && !this.vulnerable && Time.time > this.shieldBrokenTimer)
		{
			AttackBox component = col.GetComponent<AttackBox>();
			if (component && component.attackType == "player")
			{
				GameObject gameObject = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/Enemy/Spearman/ShieldBlock"), base.transform.position, Quaternion.identity);
				gameObject.transform.Rotate(0f, 0f, (float)UnityRandom.Range(0, 359));
				gameObject.transform.position = col.gameObject.transform.position + col.gameObject.transform.forward;
				return;
			}
		}
		else if (this.vulnerable && this.phase == 1)
		{
			AttackBox component2 = col.GetComponent<AttackBox>();
			if (component2 && component2.damage > 24 && component2.attackType == "player")
			{
				this.BreakShield();
				if (!this.hasShieldBrokenYet)
				{
					this.showAura.Invoke();
					this.boss.introtrack = this.boss.phases[1];
					this.boss.ForceIntro();
					this.boss.incomingPhase = 2;
					this.hasShieldBrokenYet = true;
				}
				this.CameraShake(0.5f);
			}
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00014CE8 File Offset: 0x00012EE8
	public void StartAtPhase3()
	{
		this.nohitreset = false;
		this.ebase = base.GetComponent<EnemyBase>();
		this.phase = 3;
		this.attackCD = Time.time + 1f;
		this.ai = 3;
		this.ebase.shielded = true;
		this.ebase.hp = 1f;
		this.fillingHP = true;
		this.ebase.def = -4;
		this.wingSR.color = this.phase3WingColor;
		this.wingPS.particle = this.phase3WingParticle;
		this.spearPS.particle = this.phase3SpearParticle;
		this.sr = base.GetComponent<SpriteRenderer>();
		this.sr.sprite = this.phase3Sprite;
		Boss component = base.GetComponent<Boss>();
		component.bossbarcolor = this.phase3hpcolor;
		component.bossbardelaycolor = this.phase3hpdelaycolor;
		component.bossbarbackcolor = this.phase3hpbackcolor;
		component.setAudioPhaseImmediately(3);
		this.phase3.Invoke();
		this.movementSpeed = 3.5f; //was 2.5
		base.GetComponent<PhysicsParticleGenerator>().enabled = true;
		UnityObject.FindFirstObjectByType<BossBarManager>().delayhp = 1f;
		UnityObject.FindFirstObjectByType<BossBarManager>().boss = component;
		this.eyeObject.SetActive(true);
		this.ebase.cannotBeKnocked = true;
		this.spearParent = this.spear.transform.parent.gameObject;
		this.GetSpearParent().transform.localPosition = new Vector2(0f, -0.25f);
		this.GetSpear().GetComponent<SpriteRenderer>().sprite = this.phase3Spear;
		player.midairJumpsMax = 1; //reset player dash count to prevent abuse
	}

	//Spawns one clone for specified amount of time
	[HideFromIl2Cpp]
	private void EnlightenedClone(GameObject original, KaizoSpearBoss originalController, int time) {
		GameObject clone1 = UnityEngine.Object.Instantiate(cleanClone);
		KaizoSpearBoss clone1Controller = clone1.GetComponent<KaizoSpearBoss>();
		clone1Controller.GetComponent<EnemyBase>().canDie = false;
		clone1Controller.phase = 4;
		clone1Controller.ai = 3;
		clone1Controller.battleOrigin = originalController.battleOrigin;
		clone1Controller.camHover = UnityObject.FindFirstObjectByType<CameraController>().transform.parent.GetComponent<Hover>();
		clone1Controller.rb = clone1.GetComponent<Rigidbody2D>();
		clone1Controller.sm = original.GetComponent<SaveManager>();
		UnityEngine.Object.Destroy(clone1.GetComponent<UnityEngine.AudioSource>());
		//clone1.transform.position = original.transform.position;				//For some reason this breaks the clone's ai?
		clone1.SetActive(true);
		clone1.GetComponent<KaizoSpearBoss>().initialized = true;
		UnityEngine.Object.Destroy(clone1, 8f);
	}




	/*
	 * Enlightened Attacks
	 */


	//Enlightened spin lunge
	private void EnlightenedSpinLunge(int variant) {
		switch (variant) {
			case 0:
				if (this.closeToPlayer) {
					this.lungeAtPlayer(new Vector2(10f, 1f));
					UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
					this.spinTimer = Time.time + 1.6f;
					this.attackCD = Time.time + 5f;
				}
				else {
					this.advancing = true;
					this.spearTargetPos = new Vector2(-1f, 0.5f);
					this.attackCD = Time.time + 5f;
				}
				this.advancing = true;
				this.attackCD = Time.time + 2f;
				break;
			case 1:
				this.lungeAtPlayer(new Vector2(10f, 1f));
				UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
				this.spinTimer = Time.time + 2f;
				this.attackCD = Time.time + 5f;
				break;
		}
	}

	//Enlightened lunge
	private void EnlightenedLunge(int variant) {
		switch (variant) {
			case 0:
				if (this.closeToPlayer) {
					this.spearMoveSpeed = 4f;
					this.spearTargetPos = new Vector2(1f, 0f);
					this.lungeAtPlayer(new Vector2(10f, 1f));
					UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
					this.damageTimer = Time.time + 0.75f;
					this.attackCD = Time.time + 3f;
				}
				else {
					this.advancing = true;
					this.spearTargetPos = new Vector2(-1f, 0.5f);
					this.attackCD = Time.time + 5f;
				}
				break;
			case 1:
				this.spearMoveSpeed = 4f;
				this.spearTargetPos = new Vector2(1f, 0f);
				this.lungeAtPlayer(new Vector2(10f, 1f));
				UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
				this.damageTimer = Time.time + 0.75f;
				this.attackCD = Time.time + 3.5f;
				break;
		}
	}

	//Enlightened spear rain
	private void EnlightenedSpearRain(int variant) {
		switch (variant) {
			case 0:
				if (this.closeToPlayer) {
					this.spawnSpears(25);
					this.spearMoveSpeed = 2f;
					this.spearTargetPos = new Vector2(0f, 1.25f);
					UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
					this.attackCD = Time.time + 3f;
				}
				else {
					this.spearMoveSpeed = 2f;
					this.lockrotation = true;
					this.spearTargetDir = Vector2.up;
					this.spearTargetPos = new Vector2(0f, 1.25f);
					this.advancing = true;
					this.attackCD = Time.time + 5f;
				}
				break;
			case 1:
				this.spawnSpears(35);
				this.spearMoveSpeed = 2f;
				this.spearTargetPos = new Vector2(0f, 2f);
				this.attackCD = Time.time + 3.5f;
				UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
				break;
		}
	}

	//Enlightened jump
	private void EnlightenedJump() {
		this.lungeAtPlayer(new Vector2(15f, 15f));
		this.spinTimer = Time.time + 2.1f;
		this.damageTimer = Time.time + 4f;
		this.attackSegmentTimer = Time.time + 1.25f;
		this.attackCD = Time.time + 4f;
	}

	//Enlightened chain attack warning
	private void EnlightenedChainAttackWarning() {
		this.CameraShake(0.5f);
		this.attackID = 10;
		this.chainattacksleft = 7;
		if (phase == 4 && UnityRandom.Range(1, 4) == 1) //phase 4 has a slight chance for a longer chain attack sequence
			this.chainattacksleft += 2;
		this.attackCD = Time.time + 2f;
		GameObject gameObject = UnityObject.Instantiate(this.eyeWarningParticle, base.transform.position, Quaternion.identity);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(0f, 1.75f, 0f);
	}

	//Enlightened summon horizontal spears
	private void EnlightenedSummonHorizontalSpears() {
		this.CameraShake(0.5f);
		for (int i = 0; i < 10; i++) {
			GameObject gameObject2 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkHorizontalSpearProjectile"), new Vector3(this.battleOrigin.x + 90f, this.battleOrigin.y + (float)i * 2.5f, base.transform.position.z), Quaternion.identity);
			gameObject2.transform.Rotate(0f, 0f, 180f);
			gameObject2.GetComponent<Projectile>().bombdelay = 1.5f;
		}
		for (int j = 0; j < 10; j++) {
			UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkHorizontalSpearProjectile"), new Vector3(this.battleOrigin.x - 90f, this.battleOrigin.y + 1.25f + (float)j * 2.5f, base.transform.position.z), Quaternion.identity).GetComponent<Projectile>().bombdelay = 1.5f;
		}
		this.attackCD = Time.time + .1f;
	}

	//Enlightened supreme rain start
	private void EnlightenedSupremeRainStart() {
		this.CameraShake(0.5f);
		this.rb.gravityScale = 0.1f;
		this.attackCD = Time.time + 12f;
		this.attackSegmentTimer = Time.time + 2.5f;
		this.spinTimer = Time.time + 2.5f;
		this.lungeAtPlayer(new Vector2(6f, 30f));
	}

	//Enlightened chain attack
	private void EnlightenedChainAttack()
	{
		this.attackCD = Time.time + 0.5f;
		if (this.chainattacksleft == 0) {
			this.lungeAtPlayer(new Vector2(10f, 1f));
			this.spinTimer = Time.time + 1.5f;
			this.attackCD = Time.time + 3f;
		}
		else if (this.chainattacksleft % 2 == 0) {
			this.lungeAtPlayer(new Vector2(7f, 0f));
			this.spinSpeed = -1f;
			this.spinTimer = Time.time + 0.25f;
			this.attackCD = Time.time + 0.35f;
			if (this.GetPlayer().transform.position.x > base.transform.position.x) {
				this.GetSpearParent().transform.rotation = Quaternion.Euler(0f, 0f, 70f);
			}
			else {
				this.GetSpearParent().transform.rotation = Quaternion.Euler(0f, 0f, -110f);
			}
		}
		else {
			this.lungeAtPlayer(new Vector2(7f, 0f));
			this.spinSpeed = 1f;
			this.spinTimer = Time.time + 0.25f;
			this.attackCD = Time.time + 0.35f;
			if (this.GetPlayer().transform.position.x > base.transform.position.x) {
				this.GetSpearParent().transform.rotation = Quaternion.Euler(0f, 0f, -70f);
			}
			else {
				this.GetSpearParent().transform.rotation = Quaternion.Euler(0f, 0f, 110f);
			}
		}
		UnityObject.Instantiate(this.eyeParticle, base.transform.position, Quaternion.identity).transform.parent = base.transform;
	}

	//Enlghtened supreme rain
	private void EnlightenedSupremeRain() {
		EnlightenedClone(this.gameObject, this, 8); //Spawn a clone that sticks around for 8 seconds
		for (int k = 0; k < 30; k++) {
			GameObject gameObject3 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkRetargetSpearProjectile"), new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z), Quaternion.identity);
			gameObject3.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
			gameObject3.GetComponent<Projectile>().bombdelay = 0.5f + (float)k * 0.15f;
		}
	}

	//Enlightened jump attack
	private void EnlightenedJumpAttack() {
		this.rb.gravityScale = 2f;
		GameObject gameObject4 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkSlowSpearProjectile"), base.transform.position, Quaternion.identity);
		gameObject4.transform.right = new Vector2(this.GetPlayer().transform.position.x, this.GetPlayer().transform.position.y) - new Vector2(base.transform.position.x, base.transform.position.y);
		for (int l = 0; l < 8; l++) {
			GameObject gameObject5 = UnityObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Spearman/DarkSlowSpearProjectile"), gameObject4.transform.position, gameObject4.transform.rotation);
			gameObject5.transform.Rotate(0f, 0f, (float)(-45 + 10 * l));
			gameObject5.GetComponent<Projectile>().bombdelay = 0.5f;
		}
		gameObject4.GetComponent<Projectile>().bombdelay = 0f;
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