using UnityEngine;
using System.Collections;
using Monsters;
using Design;
using CharacterControl;

public class AttackableMonster : Attackable {


    public Monster monsterReference;

    
    // Use this for initialization
	void Start () {

        monsterReference = CharacterDesign.CharacterModule(gameObject) as Monster; 	
	}


    public override void OnAttack(BaseCharacterController Attacker)
    {

        monsterReference.OnHit(Attacker);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
