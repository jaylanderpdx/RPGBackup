using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Monsters
{

    public class Monster : MonoBehaviour
    {


        PlayerTypes monsterType;
        protected GameObject playerEnteredRange;
        public GameObject combatText;
        protected PlayerStats monsterStats;
        protected MovementController movementController;
        public Collider2D attackRange;
        public bool playerInAttackRange;
        protected int updateAIEvery = 10; // c
        protected int currentFrameRef = 0;

        //PlayerDesc monsterLookup;


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
            monsterStats = GetComponentInParent<PlayerStats>();
            movementController = GetComponentInParent<MovementController>();
            
        }

        // Use this for initialization
        void Start()
        {

            monsterType = PlayerTypes.Monster;




        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                playerInAttackRange = true;
                playerEnteredRange = col.gameObject;
            }
        }


        void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag == "Player")
                playerInAttackRange = false;
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

        public void FaceAnObject(GameObject ObjectToFace)
        {

            Vector2 ObjectLocation = ObjectToFace.transform.position;
            Vector2 MonsterLocation = gameObject.transform.position;
            Vector2 Difference = ObjectLocation - MonsterLocation;
            movementController.SetMoveDirection(Difference);

        }

        virtual public void DoAi()
        {


        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}