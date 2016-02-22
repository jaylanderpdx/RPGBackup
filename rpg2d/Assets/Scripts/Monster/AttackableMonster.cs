using UnityEngine;
using System.Collections;
using Monsters;
using Design;

public class AttackableMonster : Attackable {


    public Monster monsterReference;

    
    // Use this for initialization
	void Start () {

        monsterReference = CharacterDesign.MonsterModule(gameObject); 	
	}
	

    public override void OnAttack(ItemTypes item)
    {

        monsterReference.OnHit(item);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
