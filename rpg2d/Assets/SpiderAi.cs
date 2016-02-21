using UnityEngine;
using System.Collections;
namespace Monsters
{
    public class SpiderAi : Monster
    {


        Drops drops = new Drops(2);

        public ParticleSystem slashParticle;
        public GameObject floatingCombatTxt;


       

        public override void DoAi()
        {
            base.DoAi();
           
            if (playerInAttackRange)
            {
                FaceAnObject(playerEnteredRange);

            }
            else
                movementController.SetMoveDirection(Vector2.zero);
        }

        public override void OnHit(ItemTypes item)
        {

            //  Destroy(slashParticle, slashParticle.duration);


           GameObject obj =  GameObject.Instantiate(slashParticle, transform.position, Quaternion.identity) as GameObject;

            Destroy(obj, 1f);
            
            //WorldUI.instance.DamageNormalAt (transform.position, 1);
            base.OnHit(item);
        }

        void Start()
        {

            drops.AddDrop(0, new DropListEntry(0, 1f));

        }

        // Update is called once per frame
        void Update()
        {
            currentFrameRef++;

            if (currentFrameRef > updateAIEvery)
            {
                currentFrameRef = 0;
                DoAi();
            }
        }
    }

}
