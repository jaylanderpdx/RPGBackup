using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Monsters;
using Design;

public class HandleWeaponCollision : MonoBehaviour {

    Collider2D weaponCollider;
    public MovementController playerActionController;
    public CombatController combatController;
    public MovementController moveRef;
    public ItemTypes weaponType;


    void awake()
    {
       
        Debug.Log(combatController);
    }
	// Use this for initialization
	void Start () {
        moveRef = CharacterDesign.MovementModule(gameObject);
        weaponCollider = GetComponent<Collider2D>();
        combatController = CharacterDesign.CombatModule(gameObject);
         
    }
	
	void OnTriggerStay2D(Collider2D CollidedWith)
    {

        
        Attackable CanAttackCollidedObject = CollidedWith.GetComponent<Attackable>();


        if (CanAttackCollidedObject && combatController.isAttacking)
        {
           
            GameObject obj = CollidedWith.gameObject;
            bool IsDuplicateAttack = combatController.DuplicateHit(obj);

            Vector2 FacingDirection = moveRef.facingDirection;
            Vector2 TargetEnemyLocation = CollidedWith.transform.position - gameObject.transform.position;
          

           float direction = Vector2.Dot(FacingDirection, TargetEnemyLocation);
           float angle = Vector2.Angle(FacingDirection, TargetEnemyLocation);
        
            if (!IsDuplicateAttack && angle < 60f)
            {
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
