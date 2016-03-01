using UnityEngine;
using System.Collections;
using Interactions;
using Design;
/*
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

      //public InputController inputController;

        public CombatController combatController;
        public MovementController movementController;
        public InteractionController interactionController;
        public AnimationController animationController;
        public PlayerStats playerStats;
       public static BaseCharacterController instance;
        public ControlFlags controlState;
        public bool characterBusy;

        public bool CheckControlState( ControlFlags StatusToTest)
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

        // Use this for initialization

        public void Setup()
        {
            combatController = CharacterDesign.CombatModule(gameObject);
            movementController = CharacterDesign.MovementModule(gameObject);
            interactionController = CharacterDesign.InteractionModule(gameObject);
            animationController = CharacterDesign.AnimationModule(gameObject);
        }

        virtual public void OnHit(ItemTypes Item)
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}

    */