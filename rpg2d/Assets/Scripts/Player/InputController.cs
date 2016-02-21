using UnityEngine;

using System.Collections;
using Interactions;

public class InputController : MonoBehaviour {


    MovementController movementController;
    InteractionController interactionController;
    Animator anim;
    public static InputController Instance;
  
  
    float attackSpeed;
    float attackTimer;

    void Awake()
    {
        movementController = GetComponent<MovementController>();
        interactionController = GetComponent<InteractionController>();
    }
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        Instance = this;
        attackSpeed = .5f;
        attackTimer = 0f;
    }

    
    void SetMovement(Vector2 mov)
    {

        anim.SetFloat("move_x", mov.x);
        anim.SetFloat("move_y", mov.y);
        
    }


    void StopWalkingAnimation( Vector2 Facing)
    {
        SetMovement(Facing);
        anim.SetBool("walking", false);

    }

    void UpdateMovement()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 Facing = movementController.GetFacingDirection();
        bool walking = (move != Vector2.zero);

         if (walking)
            SetMovement(move);

        movementController.SetMoveDirection(move);
        anim.SetBool("walking", walking);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (!movementController.IsBusy())
            UpdateMovement();

        else
        {
            if (attackTimer < attackSpeed)
                attackTimer += Time.deltaTime;

            else
            {
                movementController.isAttacking = false;
                attackTimer = 0f;
            }

        }

            if (Input.GetKeyDown(KeyCode.Space))
            {
           bool DidInteractionHappen = interactionController.DoInteraction();
            if (DidInteractionHappen)
            {

                 if( movementController.waitForKeypress = !movementController.waitForKeypress)
                     StopWalkingAnimation(movementController.GetFacingDirection());

            }

            }

            if (Input.GetButtonDown("Fire1") && !movementController.isAttacking)
            {
          
                anim.SetTrigger("attacking");
                movementController.isAttacking = true;
                movementController.beginAttack = true;
                StopWalkingAnimation(movementController.GetFacingDirection());

            }
            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("casting");
            }

        
       


    }  
}
