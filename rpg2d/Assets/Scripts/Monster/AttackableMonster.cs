using UnityEngine;
using System.Collections;

public class AttackableMonster : Attackable {


    Monster monsterReference;

    
    // Use this for initialization
	void Start () {

        monsterReference = GetComponent<Monster>();
        	
	}
	

    public override void OnAttack(ItemTypes item)
    {

        monsterReference.OnHit(item);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
