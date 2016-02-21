using UnityEngine;
using System.Collections;

public class SpiderAi : Monster {

  
    Drops drops = new Drops(2);
    public GameObject floatingCombatTxt;




    public override void OnHit(ItemTypes item)
    {

        base.OnHit(item);
    }

    void Start () {
        
        drops.AddDrop(0, new DropListEntry(0,1f));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentFrameRef++;

        if ( currentFrameRef > updateAIEvery)
        {
            currentFrameRef = 0;
            DoAi();
        }
	}
}
