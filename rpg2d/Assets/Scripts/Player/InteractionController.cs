using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Interactions
{
    public class InteractionController : MonoBehaviour
    {


        MovementController movementController;
        public float interactionRadius = .001f;
        public float interactionFOV = 40f;
        // Use this for initialization


        void Awake()
        {
            movementController = GetComponent<MovementController>();
        }

        void Start()
        {

        }

        public bool DoInteraction()
        {
            Interactable FoundAnInteraction = FindNearestInteractable();

            if (FoundAnInteraction)
                 FoundAnInteraction.OnInteract();

            return (FoundAnInteraction == true);
           

        }
        public Interactable FindNearestInteractable()
        {

            Interactable BestChoiceForInteraction, CurrentInteractableInRange;
            BestChoiceForInteraction = CurrentInteractableInRange = null;
            float BestViewAngle = Mathf.Infinity;

            Collider2D[] CollidersInRangeOfPlayer = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

            foreach (Collider2D col in CollidersInRangeOfPlayer)
            {
                if (CurrentInteractableInRange = col.GetComponent<Interactable>()) //can we interact with the current object we've collided with?
                {

                    Vector3 Facing = movementController.GetFacingDirection();
                    Vector3 Difference = col.transform.position - transform.position;
                    float AnglePlayerFacingToInteraction = Vector2.Angle(Difference, Facing);
                    if (AnglePlayerFacingToInteraction < interactionFOV) //is the interaction in Field of View?
                    {
                        if (AnglePlayerFacingToInteraction < BestViewAngle)
                        {
                            BestViewAngle = AnglePlayerFacingToInteraction;
                            BestChoiceForInteraction = CurrentInteractableInRange;
                        }
                    }
                }
            }

            return BestChoiceForInteraction;
        }




        // Update is called once per frame
        void Update()
        {

            //  DoInteraction();
        }
    }
}