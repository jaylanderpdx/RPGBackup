using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Design;
namespace Monsters
{

    public class Monster : MonoBehaviour
    {


        PlayerTypes monsterType;
        protected GameObject playerEnteredRange;
        public GameObject combatText;
        protected PlayerStats monsterStats;
        protected CombatController combatController;
        protected MovementController movementController;
        public Collider2D attackRange;
        public bool playerInAttackRange;
        public bool playerInView;
        public float attackRadius;
        protected int updateAIEvery = 10; // c
        protected int currentFrameRef = 0;

     

        void CreateCombatText(string s)
        {

            GameObject obj = Instantiate(combatText);
            RectTransform rect = obj.GetComponent<RectTransform>();

            GameObject monster = gameObject.transform.parent.FindChild("UI").gameObject;
            GameObject canvas =  monster.GetComponent<Canvas>().gameObject;
            rect.localPosition = combatText.transform.localPosition;
            rect.localScale = combatText.transform.localScale;
            rect.localRotation = combatText.transform.localRotation;
            Text ct = obj.GetComponent<Text>();
            
            ct.text = s;
            obj.transform.SetParent(canvas.transform);
            Destroy(obj, 1f);

            }

    public void Awake()
        {
            
            monsterStats = CharacterDesign.StatsModule(gameObject);//GetComponentInParent<PlayerStats>();
            movementController = CharacterDesign.MovementModule(gameObject);
            combatController = CharacterDesign.CombatModule(gameObject);
            monsterStats = CharacterDesign.StatsModule(gameObject);
            
        }

        // Use this for initialization
        void Start()
        {
           CircleCollider2D  col = combatController.GetComponent<CircleCollider2D>() ;
            attackRadius = col.radius;
            Debug.Log(attackRadius);
            monsterType = PlayerTypes.Monster;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                playerInView = true;
                playerEnteredRange = col.gameObject;
                
            }
        }


        void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                playerInView = false;
                playerEnteredRange = null;
            }   
        }

        
        public virtual void OnHit(ItemTypes HitByWhat)
        {

            int dmg = 10;
            monsterStats.currentHealth--;
            
            if (monsterStats.currentHealth <= 0)
                DestroyObject(gameObject.transform.parent.gameObject);
            CreateCombatText(dmg.ToString());
        }

        public void FindPathTo(Vector3 MoveHere)
        {

        }

        public bool ObjectInFOV(GameObject ObjectToCheck)
        {

            return true;
        }
/*
        public void FaceAnObject(GameObject ObjectToFace)
        {

            Vector2 ObjectLocation = ObjectToFace.transform.position;
            Vector2 MonsterLocation = gameObject.transform.position;
            Vector2 Difference = ObjectLocation - MonsterLocation;
            movementController.SetMoveDirection(Difference);

        }
        */
        virtual public void DoAi()
        {


        }
        // Update is called once per frame
      
    }
}