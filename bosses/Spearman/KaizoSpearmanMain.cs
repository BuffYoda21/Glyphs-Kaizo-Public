using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace GlyphsKaizo.Bosses.Spearman {
    public class KaizoSpearmanMain {
        public static void Initialize(GameObject spearman) {
			SpearBoss oldSpearmanController = spearman.GetComponent<SpearBoss>();
			if (oldSpearmanController == null) {
				MelonLogger.Warning("Spearman not found or already initialized.");
				return;
			}
			spearman.AddComponent<KaizoSpearBoss>();
			KaizoSpearBoss spearmanController = spearman.GetComponent<KaizoSpearBoss>();
            TranferState(oldSpearmanController,spearmanController);
			UnityEngine.Object.DestroyImmediate(oldSpearmanController);
            if(oldSpearmanController.phase == 1) {
                spearmanController.movementSpeed = 2;
                spearmanController.spinSpeed = 5;
				spearman.AddComponent<KaizoSpearBossCoroutineHelper>();
				spearman.GetComponent<KaizoSpearBossCoroutineHelper>().spearman = spearman;
				spearman.GetComponent<KaizoSpearBossCoroutineHelper>().spearmanController = spearmanController;
            }
        }

        //The stupid ahhh method that im too stupid to figure out how to do more efficently
        private static void TranferState(SpearBoss Original, KaizoSpearBoss Updated) {
	        Updated.onGuard = Original.onGuard;
	        Updated.closeToPlayer = Original.closeToPlayer;
	        Updated.spearCanDamage = Original.spearCanDamage;
	        Updated.advancing = Original.advancing;
	        Updated.lockrotation = Original.lockrotation;
	        Updated.vulnerable = Original.vulnerable;
	        Updated.rainAttackDue = Original.rainAttackDue;
	        Updated.screenshakeinitiated = Original.screenshakeinitiated;
	        Updated.nohitreset = Original.nohitreset;
	        Updated.attackRadius = Original.attackRadius;
	        Updated.closeRadius = Original.closeRadius;
	        Updated.spinTimer = Original.spinTimer;
	        Updated.damageTimer = Original.damageTimer;
	        Updated.attackCD = Original.attackCD;
	        Updated.movementSpeed = Original.movementSpeed;
	        Updated.spearMoveSpeed = Original.spearMoveSpeed;
	        Updated.vulnerableTimer = Original.vulnerableTimer;
	        Updated.shieldBrokenTimer = Original.shieldBrokenTimer;
	        Updated.lastplayerhp = Original.lastplayerhp;
	        Updated.attackSegmentTimer = Original.attackSegmentTimer;
	        Updated.spinSpeed = Original.spinSpeed;
	        Updated.supremeRainCalls = Original.supremeRainCalls;
	        Updated.cameraShakeEndtime = Original.cameraShakeEndtime;
	        Updated.flightSpeed = Original.flightSpeed;
	        Updated.flightTarget = Original.flightTarget;
	        Updated.poise = Original.poise;
	        Updated.attackID = Original.attackID;
	        Updated.phase = Original.phase;
            Updated.ai = Original.ai;
	        Updated.chainattacksleft = Original.chainattacksleft;
	        //Updated.parryCD = Original.parryCD;
	        //Updated.player = Original.player;
	        //Updated.ebase = Original.ebase;
	        Updated.spear = Original.spear;
	        Updated.spearParent = Original.spearParent;
	        Updated.parryObject = Original.parryObject;
	        Updated.attackObject = Original.attackObject;
	        Updated.shieldObj = Original.shieldObj;
	        Updated.shieldParticle = Original.shieldParticle;
	        Updated.shieldBreakParticle = Original.shieldBreakParticle;
	        Updated.shieldColor = Original.shieldColor;
	        Updated.vulnerableColor = Original.vulnerableColor;
	        Updated.spearTargetDir = Original.spearTargetDir;
	        Updated.spearTargetPos = Original.spearTargetPos;
	        Updated.battleOrigin = Original.battleOrigin;
	        Updated.hasShieldBrokenYet = Original.hasShieldBrokenYet;
	        Updated.showAura = Original.showAura;
	        Updated.phase2 = Original.phase2;
	        Updated.phase3 = Original.phase3;
	        //Updated.rb = Original.rb;
	        //Updated.sm = Original.sm;
	        Updated.fillingHP = Original.fillingHP;
	        Updated.phase3WingParticle = Original.phase3WingParticle;
	        Updated.phase3SpearParticle = Original.phase3SpearParticle;
	        Updated.eyeParticle = Original.eyeParticle;
	        Updated.eyeObject = Original.eyeObject;
	        Updated.eyeWarningParticle = Original.eyeWarningParticle;
	        Updated.phase3WingColor = Original.phase3WingColor;
	        Updated.phase3SpearColor = Original.phase3SpearColor;
	        Updated.phase3hpcolor = Original.phase3hpcolor;
        	Updated.phase3hpdelaycolor = Original.phase3hpdelaycolor;
        	Updated.phase3hpbackcolor = Original.phase3hpbackcolor;
	        Updated.spearSR = Original.spearSR;
        	Updated.wingSR = Original.wingSR;
	        Updated.spearPS = Original.spearPS;
        	Updated.wingPS = Original.wingPS;
	        //Updated.camHover = Original.camHover;
    	    //Updated.sr = Original.sr;
	        //Updated.boss = Original.boss;
	        Updated.phase3Sprite = Original.phase3Sprite;
    	    Updated.phase3Spear = Original.phase3Spear;
        }    
    }
}