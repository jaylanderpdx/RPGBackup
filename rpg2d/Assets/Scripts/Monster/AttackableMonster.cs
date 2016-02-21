using UnityEngine;
using System.Collections;
using Monsters;

public class AttackableMonster : Attackable {


    public Monster monsterReference;

    
    // Use this for initialization
	void Start () {

        monsterReference = GetComponentInChildren<Monster>();
        	
	}
	

    public override void OnAttack(ItemTypes item)
    {

        monsterReference.OnHit(item);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
