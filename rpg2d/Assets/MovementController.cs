using UnityEngine;
using System.Collections;
using CharacterControl;

public class MovementController : MonoBehaviour {


    public Vector3 moveDirection;
    public Vector3 facingDirection;
    public float moveSpeed;
    public bool waitForKeypress;
    public bool isBusy;
    private Rigidbody2D characterBody;
  
    private Vector2 hitDirection;
    private float hitTime;
    public bool isBeingPushed;

    public float DRTimer = 0f;
    public float DRReset = 6.0f;
    private float currentDR;


    void Awake()
    {
        characterBody = GetComponent<Rigidbody2D>();
    }
    void Start () {

     
        facingDirection.Set(0f, -1f, 0f);
	}


    public void GetPushedFrom(MovementController PushedFrom, float strength, float time)
    {
        Vector2 diff = transform.position - PushedFrom.transform.position;

        if (diff != Vector2.zero)
            diff.Normalize();
        Knockback(diff * strength, time);
    }


    public void Knockback(Vector2 Directon, float OverTime)
    {

        if (DRTimer != 0f)
        {
            currentDR *= .75f;
             if(currentDR > .25f)
             {
               // DRTimer = DRReset;
                hitTime = OverTime * currentDR;
                hitDirection = Directon;
                //hitDirection.Normalize();
             } 
             else
            {
               
                if(DRTimer == 0f)
                {
                    currentDR = 1f;
                   
                }
            }
        }
        else
        {
            DRTimer = DRReset;
            currentDR = 1f;
            hitTime = OverTime;
            hitDirection = Directon;
        }
    }


    public bool IsFacing( BaseCharacterController TargetToFace)
    {
        return (facingDirection == TargetToFace.movementController.facingDirection);
    }

    public void TurnToward ( BaseCharacterController TargetToFace)
    {

        facingDirection = TargetToFace.movementController.facingDirection;
    }

    public void Face( GameObject TargetToFace)
    {

       Vector2 TargetLocation = TargetToFace.transform.position;
       Vector2 ThisLocation = gameObject.transform.position;
       Vector2 Difference = TargetLocation - ThisLocation;
       SetMoveDirection(Difference);

    
}

    public bool IsBusy()
    {
        return waitForKeypress || isBusy;
    }

	void FixedUpdate()
    {
        UpdateMovement();
    }
    
    
    public void UpdateBusyStatus(bool busy)
    {
        isBusy = busy;

    }

   
    public void SetMoveDirection(Vector2 NewDirection) 
    {

        if (isBusy && hitTime <= 0f)
            return;

        moveDirection = new Vector3(NewDirection.x, NewDirection.y);

        if(moveDirection != Vector3.zero)
           facingDirection = moveDirection; //only change facing direction after moving
        
    }

    public void StopMovement()
    {
        moveDirection.x = 0f;
        moveDirection.y = 0f;
        this.isBeingPushed = false;
        this.hitTime = 0f;
        this.hitDirection = Vector2.zero;
        Rigidbody2D rbod = GetComponent<Rigidbody2D>();
        rbod.velocity = Vector2.zero;
    }

    public void Pause()
    {
        StopMovement();
        Rigidbody2D rbod = GetComponent<Rigidbody2D>();
        rbod.velocity = Vector2.zero;
        enabled = false;

    }
    public Vector3 GetFacingDirection()
    {
        return facingDirection;
    }

    void UpdateMovement()
    {

        Rigidbody2D rbod = GetComponent<Rigidbody2D>();



        if (!waitForKeypress)
        {

            
                    if (moveDirection != Vector3.zero)
                        Vector3.Normalize(moveDirection);


            if (hitTime > 0f)
            {
                isBeingPushed = true;
                rbod.velocity = hitDirection;
            }
            else
            {
                isBeingPushed = false;
                if (!isBusy)
                    rbod.velocity = moveDirection * moveSpeed;
                else
                    rbod.velocity = Vector2.zero;
            }

        }
        else
            rbod.velocity = Vector2.zero;

    }
    
    void Update()
    {

            hitTime = Mathf.MoveTowards(hitTime, 0f, Time.deltaTime);
        DRTimer = Mathf.MoveTowards(DRTimer, 0f, Time.deltaTime);
    } 
    
}
