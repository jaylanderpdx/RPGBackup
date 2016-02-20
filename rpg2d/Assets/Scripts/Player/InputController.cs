using UnityEngine;

using System.Collections;
using Interactions;

public class InputController : MonoBehaviour {


    MovementController movementController;
    InteractionController interactionController;
    Animator anim;
    public static InputController Instance;
    public bool isAttacking;
  

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

    
    void UpdateMovement()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool walking = (move != Vector2.zero);
            if (walking)
            {
            anim.SetFloat("move_x", move.x);
            anim.SetFloat("move_y", move.y);
            }
        movementController.SetMoveDirection(move);
        anim.SetBool("walking", walking);
    }
    
    // Update is called once per frame
    void Update()
    {


        UpdateMovement();
        if (!isAttacking)
        {


            if(Input.GetKeyDown(KeyCode.Space))
            {
                interactionController.DoInteraction();
             //   movementController.DisableMovement();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attacking");
                isAttacking = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("casting");
            }

        }
        else
        {

            if (attackTimer < attackSpeed)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }


    }  
}
