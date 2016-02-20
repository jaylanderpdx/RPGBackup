using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {


    public Vector3 moveDirection;
    public Vector3 facingDirection;
    public float moveSpeed;
    public bool canMoveRightNow;
    private Rigidbody2D characterBody;
    // Use this for initialization


    void Awake()
    {
        characterBody = GetComponent<Rigidbody2D>();
    }
    void Start () {

        canMoveRightNow = true;
        facingDirection.Set(0f, 1f, 0f);
	}
	
	void FixedUpdate()
    {
        UpdateMovement();
    }


    public void DisableMovement()
    {
        canMoveRightNow = false;
    }

    public void EnableMovement()
    {
        canMoveRightNow = true;

    }

    public void SetMoveDirection(Vector2 NewDirection)
    {
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

        if (canMoveRightNow)
        {

            if (moveDirection != Vector3.zero)
                Vector3.Normalize(moveDirection);

            rbod.velocity = moveDirection * moveSpeed;
        }
        else
            rbod.velocity = Vector2.zero;
       }
     
    
}
