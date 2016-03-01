using UnityEngine;
using System.Collections;
using Interactions;
using Design;

namespace CharacterControl
{

    public enum ControlFlags
    {
        None = 000,
        Attacking = 0x001,
        Paused = 0x002,
        Busy = 0x004,
        WaitingForKeypress = 0x008,
        WaitingForCinema = 0x010,
        Waiting = WaitingForKeypress | WaitingForCinema,
        Dying = 0x020
    };

    public class BaseCharacterController : MonoBehaviour
    {
        public CombatController combatController;
        public MovementController movementController;
        public InteractionController interactionController;
        public AnimationController animationController;
        public PlayerStats playerStats;
        public static BaseCharacterController instance;
        public ControlFlags controlState;
        public int currentLevel = 1;
        
        public bool Dying
        {

            get
            {
                return CheckControlState(ControlFlags.Dying);
            }

        }

        public string GetTag()
        {
            return gameObject.transform.parent.gameObject.tag;

        }


        public void OnKnockback(BaseCharacterController CharacterPushing, float strength, float time)
        {
            MovementController tomove = CharacterPushing.movementController;
            movementController.GetPushedFrom(tomove, strength, time);
        }
      
        public virtual void Pause()
        {
            combatController.enabled = false;

            movementController.Pause();

            SetControlState(ControlFlags.Paused);
        }

        void UnPause()
        {
            combatController.enabled = true;
            movementController.StopMovement();
           // movementController.enabled = true;
            animationController.enabled = true;
            interactionController.enabled = true;
            ClearFlagState(ControlFlags.Paused);   
    }

        public bool CheckControlState(ControlFlags StatusToTest)
        {
            
            ControlFlags MaskApplied = StatusToTest & controlState;
            int val = (int)(MaskApplied);
            return (val > 0);
        }

        public void ClearFlagState(ControlFlags FlagsToClear)
        {
            ControlFlags MaskApplied = ~FlagsToClear;
            controlState &= MaskApplied;
        }

        public void SetControlState(ControlFlags FlagsToSet)
        {
            controlState |= FlagsToSet;
        }

        public void Setup()
        {
            combatController = CharacterDesign.CombatModule(gameObject);
            movementController = CharacterDesign.MovementModule(gameObject);
            interactionController = CharacterDesign.InteractionModule(gameObject);
            animationController = CharacterDesign.AnimationModule(gameObject);
            playerStats = CharacterDesign.StatsModule(gameObject);
        }

        virtual public void OnHit(BaseCharacterController Attacker)
        {
            
        }

        virtual public void DoAttack(GameObject AttackTarget)
        {

        }

        void Start()
        {
            Setup();
            instance = this;

        }

        void Update()
        {

        }

        public void DisableUI()
        {
            GameObject go = gameObject.transform.parent.Find("UI").gameObject;
            Canvas canvas = go.GetComponent<Canvas>();

            if (canvas)
                canvas.enabled = false;
               
        }
    }
}