﻿using UnityEngine;
using System.Collections;
using Design;

public class AttackablePlayer : Attackable {


    CombatController combatController;
    
    // Use this for initialization
	void Start () {

        combatController = CharacterDesign.CombatModule(gameObject);
	
	}

    public override void OnAttack(ItemTypes item)
    {
        combatController.statsReference.currentHealth--;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
