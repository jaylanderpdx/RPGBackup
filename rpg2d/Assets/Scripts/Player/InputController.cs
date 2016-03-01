using UnityEngine;
using UnityEngine.UI;
using Monsters;
using Design;
using System.Collections;
using Interactions;
using CharacterControl;

public class InputController : BaseCharacterController
{



   public GameObject combatTextPrefab;
   
    private float threshhold = .5f;
    private Vector2 currentSpeed;


    public override void Pause()
    {
        base.Pause();
    }

   public void EnterCombatText(string s)
    {
        GameObject obj = Instantiate(combatTextPrefab, transform.position, Quaternion.identity) as GameObject;
        RectTransform rect = obj.GetComponent<RectTransform>();
        GameObject player = gameObject.transform.parent.FindChild("UI").gameObject;
        GameObject canvas = player.GetComponent<Canvas>().gameObject;
        Text ct = obj.GetComponent<Text>();

        ct.text = s;
        obj.transform.SetParent(canvas.transform);
      

    }

    void Awake()
    {
        Setup();
    }
    // Use this for initialization
    void Start()
    {
  //      Instance = this;
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
        bool HasDiagonalInput = (Mathf.Abs(NewMovingDirection.x) >= threshhold) && (Mathf.Abs(NewMovingDirection.y) >= threshhold);

            if (HasDiagonalInput)
                currentSpeed = NewMovingDirection * .75f;
            else
                currentSpeed = NewMovingDirection;

            if (!movementController.IsBusy())
                animationController.DoWalkAnimation(NewMovingDirection, HasWalkingInput);

        movementController.SetMoveDirection(currentSpeed);
    }

    void UpdateInputAttack()
    {
        combatController.UpdateAttack();
        bool ReadyToAttack = (Input.GetButtonDown("Fire1") && !combatController.isAttacking && !movementController.IsBusy() && !movementController.isBeingPushed);
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