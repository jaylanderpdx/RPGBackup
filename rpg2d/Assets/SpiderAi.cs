using UnityEngine;
using System.Collections;
namespace Monsters
{
    public class SpiderAi : Monster
    {


        Drops drops = new Drops(2);

        public ParticleSystem slashParticle;
        public GameObject floatingCombatTxt;

      

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

            if (!combatController.isAttacking)
            {
                if (playerInView)
                {
                  movementController.Face(playerEnteredRange);

                    if (playerInAttackRange)
                    {
                        bool AlreadyAttackedPlayer = combatController.DuplicateHit(playerEnteredRange);
                        if (!AlreadyAttackedPlayer)
                        {
                            combatController.LogAttackEntry(playerEnteredRange);
                            combatController.BeginAttack();
                        }
                    }
                }
                else {
                    // 
                    combatController.EndAttack();
                }
            }
            else {
                combatController.UpdateAttack();
                movementController.StopMovement();
            }                              

               
           }

        public override void OnHit(ItemTypes item)
        {
            GameObject obj = GameObject.Instantiate(slashParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(obj, 1f);
            base.OnHit(item);
        }

    
        void Update()
        {
         

            CheckAttackRange();
            DoAi();
            //}
        }
    }

}
