using UnityEngine;
using System.Collections;
using CharacterControl;

namespace Monsters
{
    public class SpiderAi : Monster
    {

        public float hitStrength = .001f;
        public float hitTime = .002f;
        Drops drops = new Drops(2);

        public ParticleSystem slashParticle;
        public GameObject floatingCombatTxt;



        public override void Pause()
        {
            base.Pause();
        }

        void CheckAttackRange()
        {

            if (playerInView && playerEnteredRange)
            {

              Vector2 v1 = gameObject.transform.position;
              Vector2 v2 = playerEnteredRange.transform.position;

               
                float distance = Vector2.Distance(v1, v2);
                if (distance <= attackRadius)
                {
       
                    playerInAttackRange = true;
                }
                else
                    playerInAttackRange = false;
            }
        }


            public override void DoAi()
            {


            if(CheckControlState(CharacterControl.ControlFlags.Dying))
            {
               
                return;
            }

            if (!combatController.isAttacking)
            {
                if (playerInView)
                {
                    animationController.DoWalkAnimation(movementController.moveDirection, true);
                    movementController.Face(playerEnteredRange);


                    if (playerInAttackRange)
                    {

                        combatController.BeginAttack();
                        animationController.DoAttackAnimation();
                    }
                }
                else {
                    
                    combatController.EndAttack();
                    animationController.StopWalkAnimation(movementController.facingDirection);
                    movementController.StopMovement();
                }
            }
            else {
                combatController.UpdateAttack();
                movementController.StopMovement();
            }                              

               
           }

        void CreateBloodEffect()
        {
            GameObject obj = GameObject.Instantiate(slashParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(obj, 1f);
        }

        public override void OnHit(BaseCharacterController Attacker)
        {

            CreateBloodEffect();
            base.OnHit(Attacker);
        }

    
        void Update()
        {
         

            CheckAttackRange();
            DoAi();
            //}
        }
    }

}
