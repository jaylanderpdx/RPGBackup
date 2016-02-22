using UnityEngine;
using Monsters;
using Design;
using System.Collections;
using Interactions;

public class InputController : MonoBehaviour
{


    MovementController movementController;
    InteractionController interactionController;
    CombatController combatController;
    AnimationController animationController;
    public static InputController Instance;


    void Awake()
    {
        movementController = CharacterDesign.MovementModule(gameObject);//GetComponent<MovementController>();
        interactionController = CharacterDesign.InteractionModule(gameObject);
        combatController = CharacterDesign.CombatModule(gameObject);
        animationController = CharacterDesign.AnimationModule(gameObject); //GetComponent<AnimationController>();
    }
    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    void StopWalkingAnimation()
    {
        animationController.StopWalkAnimation(movementController.facingDirection);
    }

    void UpdateInputMovement()
    {
        movementController.UpdateBusyStatus(combatController.isAttacking || movementController.waitForKeypress); //if the character attacks then the movement status becomes busy otherwise not busy
        Vector2 NewMovingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool HasWalkingInput = (NewMovingDirection != Vector2.zero);
        if (!movementController.IsBusy()) 
        animationController.DoWalkAnimation(NewMovingDirection, HasWalkingInput);
        movementController.SetMoveDirection(NewMovingDirection);

    }

    void UpdateInputAttack()
    {
        combatController.UpdateAttack();
        bool ReadyToAttack = (Input.GetButtonDown("Fire1") && !combatController.isAttacking && !movementController.IsBusy());
        if (ReadyToAttack)
        {
            combatController.BeginAttack();
            animationController.DoAttackAnimation();
            movementController.UpdateBusyStatus(true);
            StopWalkingAnimation();
        }
    }

    void UpdateInputInteration()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool DidInteractionHappen = interactionController.DoInteraction();
            if (DidInteractionHappen)
            {
                if (movementController.waitForKeypress = !movementController.waitForKeypress)
                    StopWalkingAnimation();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        UpdateInputMovement();
        UpdateInputAttack();
        UpdateInputInteration();


    }
}