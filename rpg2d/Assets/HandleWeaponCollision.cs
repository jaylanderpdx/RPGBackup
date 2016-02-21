using UnityEngine;
using System.Collections;

public class HandleWeaponCollision : MonoBehaviour {

    Collider2D weaponCollider;
    public MovementController PlayerActionController;
    public ItemTypes weaponType;


    void awake()
    {
        weaponCollider = GetComponent<Collider2D>(); 
    }
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D CollidedWith)
    {


        Attackable CanAttackCollidedObject = CollidedWith.GetComponent<Attackable>();

        if(CanAttackCollidedObject && PlayerActionController.isAttacking)
        {
            if (PlayerActionController.beginAttack)
            {
                CanAttackCollidedObject.OnAttack(weaponType);
                PlayerActionController.beginAttack = false;
            }

        }

    }
    
    // Update is called once per frame
	void Update ()
    {
	
	}
}
