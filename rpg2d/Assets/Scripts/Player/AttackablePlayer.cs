using UnityEngine;
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
       
        if(combatController.statsReference.currentHealth <= 0)
        {

            combatController.statsReference.currentHealth = 0;
            UIMessage.ShowMessage("You Have Died", Color.red, 0f);
            Time.timeScale = 0f;

        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
