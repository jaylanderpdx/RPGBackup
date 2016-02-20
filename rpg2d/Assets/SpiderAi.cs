using UnityEngine;
using System.Collections;

public class SpiderAi : MonoBehaviour {

    bool meleeRange;
    Drops drops = new Drops(2);
    public GameObject floatingCombatTxt;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
                 meleeRange = true;
     }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
                meleeRange = false;             
    }
    
    // Use this for initialization
    void Start () {
        meleeRange = false;
        drops.AddDrop(0, new DropListEntry(0,1f));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(meleeRange)
        {
          
            DropManager.instance.DropItemsFromList(gameObject.transform, drops);
            Instantiate(floatingCombatTxt, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            DestroyObject(gameObject);
        }
	}
}
