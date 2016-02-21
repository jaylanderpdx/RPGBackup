using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandleWeaponCollision : MonoBehaviour {

    Collider2D weaponCollider;
    public MovementController playerActionController;
    public CombatController combatController;
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
       
        if(CanAttackCollidedObject && combatController.isAttacking)
        {
            GameObject obj = CollidedWith.gameObject;
            bool IsDuplicateAttack = combatController.DuplicateHit(obj);


            if (!IsDuplicateAttack)
            {
                Debug.Log(obj);
                combatController.LogAttackEntry(obj);
                CanAttackCollidedObject.OnAttack(weaponType);
               
            }

        }

    }
    
    // Update is called once per frame
	void Update ()
    {
	
	}
}
