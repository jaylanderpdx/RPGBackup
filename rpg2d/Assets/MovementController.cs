using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {


    public Vector3 moveDirection;
    public Vector3 facingDirection;
    public float moveSpeed;
    public bool waitForKeypress;
    public bool isBusy;
    private Rigidbody2D characterBody;
    // Use this for initialization


    void Awake()
    {
        characterBody = GetComponent<Rigidbody2D>();
    }
    void Start () {

     
        facingDirection.Set(0f, -1f, 0f);
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

        if (isBusy)
            return;

        moveDirection = new Vector3(NewDirection.x, NewDirection.y);

        if(moveDirection != Vector3.zero)
           facingDirection = moveDirection; //only change facing direction after moving
        
    }

    public void StopMovement()
    {
        moveDirection.x = 0f;
        moveDirection.y = 0f;
    }

    public Vector3 GetFacingDirection()
    {
        return facingDirection;
    }

    void UpdateMovement()
    {

        Rigidbody2D rbod = GetComponent<Rigidbody2D>();

        if ( !IsBusy())//&& !isAttacking)
        {

            if (moveDirection != Vector3.zero)
                Vector3.Normalize(moveDirection);

            rbod.velocity = moveDirection * moveSpeed;
        }
        else
            rbod.velocity = Vector2.zero;
       }
     
    
}
