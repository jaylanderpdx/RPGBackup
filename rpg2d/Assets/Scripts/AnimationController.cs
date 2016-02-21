using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    Animator animationReference;
    


   public void DoAttackAnimation()
    {
       animationReference.SetTrigger("attacking");
    }

    void Awake()
    {
        animationReference = GetComponent<Animator>();
    }

	
   public void StopWalkAnimation(Vector2 Facing)
    {
        DoWalkAnimation(Facing, false);
    }


   public void DoWalkAnimation(Vector2 WalkDirection, bool WalkState)
    {
        if (WalkState)
        { 
        animationReference.SetFloat("move_x", WalkDirection.x);
        animationReference.SetFloat("move_y", WalkDirection.y);
        }
        animationReference.SetBool("walking", WalkState);
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
