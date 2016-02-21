using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


    PlayerTypes monsterType;
    PlayerStats monsterStats;
    public MovementController movementController;
    public Collider2D attackRange;
    public bool playerInAttackRange;
    float viewRadius;
    protected int updateAIEvery = 10; // c
    protected int currentFrameRef = 0;

    //PlayerDesc monsterLookup;
 
   
        void Awake()
    {
        monsterStats = GetComponent<PlayerStats>();
        
    }
        
        // Use this for initialization
    void Start ()
    {

        monsterType = PlayerTypes.Monster;
       



	}

      void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
                 playerInAttackRange = true;
       
     }


     void OnTriggerExit2D(Collider2D col)
    {
      if (col.tag == "Player")
            playerInAttackRange = false;             
     }


    public virtual void OnHit(ItemTypes HitByWhat)
    {
        
        monsterStats.currentHealth--;

        if (monsterStats.currentHealth <= 0)
            DestroyObject(gameObject);
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


    }

    virtual public void DoAi()
    {


    }
	// Update is called once per frame
	void Update () {
	
	}
}
