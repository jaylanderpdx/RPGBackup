using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Design;

public class CombatController : MonoBehaviour {

    public PlayerStats statsReference;

    List<GameObject> ObjectsHitThisAttack = new List<GameObject>();

    public bool isAttacking = false;
    public float attackSpeed = .5f;
    public float attackTimer = 0f;


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
	void Start () {

        statsReference = CharacterDesign.StatsModule(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
