using UnityEngine;
using System.Collections;
using Design;
using CharacterControl;

public class AttackablePlayer : Attackable {


    //CombatController combatController;
    BaseCharacterController character;

    
    // Use this for initialization
	void Start () {

        character = CharacterDesign.CharacterModule(gameObject);
   }

    public override void OnAttack(BaseCharacterController Attacker)
    {
        bool dying = character.CheckControlState(ControlFlags.Dying);
        if (dying) return;
        CombatController enemy = Attacker.combatController;
        CombatController combat = character.combatController;
        PlayerStats stats = character.playerStats;
        if(!enemy)
        {
            Debug.Log("Attacking with no enemy!");
            return;
        }
        combat.Damage(enemy.CurrentDamage());
        combat.EnterCombat();
        character.OnKnockback(Attacker, 2.5f, .2f);
      
        if (stats.currentHealth < 1f)
        {
            stats.currentHealth = 0f;
            character.SetControlState(ControlFlags.Dying);
            UIMessage.ShowMessage("You Have Died", Color.red, 0f);
            AnimationController anim = character.animationController;
            anim.animationReference.SetBool("dying", true);
            Pause.Go();
            character.movementController.StopMovement();
            character.movementController.enabled = false;
            character.combatController.enabled = false;
        }

   
    }

    // Update is called once per frame
    void Update () {
	
	}
}
