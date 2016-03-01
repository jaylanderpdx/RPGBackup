using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Design;
using CharacterControl;
namespace Monsters
{

    public class Monster : BaseCharacterController
    {
     
        protected GameObject playerEnteredRange;
        public GameObject combatText;
        public Collider2D attackRange;
        public bool playerInAttackRange;
        public bool playerInView;
        public float attackRadius;
        protected int updateAIEvery = 10; // c
        protected int currentFrameRef = 0;
        public int experiencePerKill = 4;

        public override void Pause()
        {
            base.Pause();

            Animator anim = gameObject.transform.parent.Find("View").GetComponent<Animator>();
            anim.enabled = false;
        } 

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

            this.Setup();
       
            
        }

        // Use this for initialization
        void Start()
        {
           CircleCollider2D  col = combatController.GetComponent<CircleCollider2D>() ;
            attackRadius = col.radius;
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
   
        public override void OnHit(BaseCharacterController Attacker)
        {

            int dmg = 1;
            if (Dying) return;
       
            combatController.Damage(Attacker.combatController.CurrentDamage());
       
            if (combatController.TestForDying())
            {

                Levelable levelup = Attacker.GetComponent<Levelable>();

                if (levelup)
                    levelup.currentxp += this.experiencePerKill;

                DisableUI();
                movementController.StopMovement();
                animationController.DoDeathAnimation();
                Rigidbody2D rbod = gameObject.transform.parent.GetComponent<Rigidbody2D>();
                BoxCollider2D box = gameObject.transform.parent.GetComponent<BoxCollider2D>();
                box.enabled = false;
                rbod.isKinematic = true;
                DestroyObject(gameObject.transform.parent.gameObject, 1.5f);
            }
            else
            {
                CreateCombatText(dmg.ToString());
                OnKnockback(Attacker, 1.5f, .4f);
            }

        }

        public void FindPathTo(Vector3 MoveHere)
        {

        }
        public bool ObjectInFOV(GameObject ObjectToCheck)
        {

            return true;
        }

        virtual public void DoAi()
        {


        }
        // Update is called once per frame
      
    }
}