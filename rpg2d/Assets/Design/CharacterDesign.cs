using UnityEngine;
using System.Collections;
using Monsters;
using Interactions;
using CharacterControl;
namespace Design
{ 

    public class CharacterDesign
    {
       
        public static InteractionController InteractionModule( GameObject GetFrom)
        {
            Transform parent = GetFrom.transform.parent;
            InteractionController inter = null;

            if (parent)
                inter = parent.gameObject.GetComponent<InteractionController>();

            return inter;
        }

      

        public static PlayerStats StatsModule(GameObject SubObject)
        {
            GameObject obj = null;
            Transform parent = SubObject.transform.parent;
            PlayerStats stats = null;
            if (parent)
                obj = parent.Find("Combat").gameObject;

            if (obj)
                stats = obj.GetComponent<PlayerStats>();

            return stats;
        }

        public static BaseCharacterController CharacterModule(GameObject GetFrom)
        {
            GameObject obj = null;
            CharacterControl.BaseCharacterController character = null;
            Transform parent = GetFrom.transform.parent;
            if (parent)
                obj = parent.Find("Controls").gameObject;

            if (obj)
                character = obj.GetComponent<BaseCharacterController>();
           
            return character;
        }

        public static AnimationController AnimationModule(GameObject GetFrom)
        { 
            GameObject obj = GetFrom.transform.parent.Find("View").gameObject;
            AnimationController anim = null;

            if (obj)
                anim = obj.GetComponent<AnimationController>();

            return anim;
        }

        public static MovementController MovementModule(GameObject GetFrom)
        {
            Transform parent = GetFrom.transform.parent;
            MovementController move = null;

            if (parent)
                move = parent.gameObject.GetComponent<MovementController>();

            return move;
        }
      
        public static CombatController CombatModule(GameObject sub)
        {
            GameObject obj = sub.transform.parent.Find("Combat").gameObject;
            CombatController combat = null;

            if (obj)
                combat = obj.GetComponent<CombatController>();

            return combat;
        }

    }
}