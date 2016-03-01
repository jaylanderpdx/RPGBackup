using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Design;
using CharacterControl;

public class CombatController : MonoBehaviour {

    // public PlayerStats statsReference;

    public BaseCharacterController character;

    List<GameObject> ObjectsHitThisAttack = new List<GameObject>();

    bool inCombat = false;
    float regen = .01f ;
    float timeToLeaveCombat = 3.0f;
    float combatTimer = 0f;
    public bool isAttacking = false;
    public float attackSpeed = .5f;
    public float attackTimer = 0f;

    public int CurrentDamage()
    {
        int damage = 1;
        return damage;
    }

    public void UpdateAttack()
    {
        if (isAttacking)
        {
            if (attackTimer < attackSpeed)
                attackTimer += Time.deltaTime;

            else
            {
                EndAttack();

            }
        }
    }

   public bool TestForDying()
    {
        PlayerStats stats = character.playerStats;
       

        if ( (int)stats.currentHealth <= 0)
        {
            stats.currentHealth = 0;
            character.SetControlState(ControlFlags.Dying);
        }
                return character.CheckControlState(ControlFlags.Dying);
    }


    public void EnterCombat()
    {

     

        if(!inCombat && character.transform.parent.gameObject.tag == "Player")
        {

            InputController ic = character as InputController;
           // ic.EnterCombatText("Entering Combat");
        }
        combatTimer = timeToLeaveCombat;
        inCombat = true;

    }

    void ExitCombat()
    {
        if (character.transform.parent.gameObject.tag == "Player")
        {

            InputController ic = character as InputController;
            //ic.EnterCombatText("Leaving Combat");
        }

        inCombat = false;
    }

    public void Damage(int damage)
    {
        PlayerStats stats = character.playerStats;
        stats.currentHealth -= damage;
    }

    void OnTriggerStay2D(Collider2D CollidedWith)
    {



        if (!isAttacking || DuplicateHit(CollidedWith.gameObject)) return;
        if (character.movementController.isBeingPushed) return;
        Attackable TargetToAttack = CollidedWith.gameObject.GetComponent<Attackable>();
        if (!TargetToAttack) return;
        if (attackTimer > attackSpeed * .5f) return;
        Transform parent = gameObject.transform.parent;
        Transform collidedparent = CollidedWith.transform.parent;

        
        if (parent && collidedparent)
        {
            string This = parent.gameObject.tag;
            string That = collidedparent.gameObject.tag;
            if (This == "Enemy" && That != "Player" || (This == That)) return;
        }


        DoAttack(TargetToAttack);
        //  Debug.Log(CollidedWith.gameObject.name);
        //return;
        /// CombatController combat = CollidedWith.gameObject.GetComponent<CombatController>();
       
        
          //  DoAttack(Attackee);
           // }
    }



    void DoAttack(Attackable Attackee)
    { 

            MovementController move = character.movementController;
            Vector2 FacingDirection = move.facingDirection;
            Vector2 TargetEnemyLocation = Attackee.transform.position - gameObject.transform.position;
                if(TargetEnemyLocation != Vector2.zero)
                    TargetEnemyLocation.Normalize();
            float direction = Vector2.Dot(FacingDirection, TargetEnemyLocation);
            float angle = Vector2.Angle(FacingDirection, TargetEnemyLocation);

            if (direction < 0f) Debug.Log("You must face your target to attack!");
            if (Mathf.Abs(angle) < 90f)
            {
              

                if (Attackee.tag == "Enemy")
                EnterCombat();
                LogAttackEntry(Attackee.gameObject);
                Attackee.OnAttack(character);
            }
        
    }

    public void BeginAttack()
    {
        attackTimer = 0f;
        isAttacking = true;
    }


    public void Attack(GameObject ToAttack)
    {

        CombatController othercombat = CharacterDesign.CombatModule(ToAttack);


    }

    public void LogAttackEntry(GameObject ObjectToLog)
    {

        ObjectsHitThisAttack.Add(ObjectToLog);
    }
    
   public bool DuplicateHit(GameObject Hit)
    {
        return (ObjectsHitThisAttack.Contains(Hit));
            }

   public void EndAttack()
    {
        ObjectsHitThisAttack.Clear();
        isAttacking = false;
    }
    
    // Use this for initialization
	void Start ()
    {
        character = CharacterDesign.CharacterModule(gameObject);
       
    }
	
	// Update is called once per frame
	void Update () {

        if(inCombat)
        {
            combatTimer -= Time.deltaTime;
            if (combatTimer <= 0f)
                ExitCombat();
            
        }
        else
        {
            PlayerStats stats = character.playerStats;
            stats.AddHealth(regen *stats.maxHealth * Time.deltaTime);
           
               
            }
	}
}
