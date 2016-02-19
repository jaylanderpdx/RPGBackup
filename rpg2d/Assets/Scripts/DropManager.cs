using UnityEngine;
using System.Collections;

public class DropListEntry
{
    public int index;
    public float dropChance;
    public DropListEntry()
    {
        index = 0;
        dropChance = 0.0f;
    }

    public DropListEntry(int i, float d)
    {
        index = i;
        dropChance = d;
    }

}

public class Drops
{

    public int maxDrops;
    public int totalDropsInList;
    const int defaultMax = 2;
    public DropListEntry[] List;

    public void AddDrop(int index, DropListEntry de)
    {
        if(index >=0 && index < totalDropsInList)
        {
            List[index].index = de.index;
            List[index].dropChance = de.dropChance;
        }
    }
    public Drops(int max)
    {
        List = new DropListEntry[max];
        totalDropsInList = max;

        for (int i = 0; i < max; i++)
            List[i] = new DropListEntry();
    }


    public Drops()
    {
        totalDropsInList = defaultMax;
        List = new DropListEntry[totalDropsInList];
        
    }
}
public class DropManager : MonoBehaviour {

    public GameObject AllDropsOnMap;
    const int MaxDropsInGame = 10;
    public static DropManager instance;
    private GameObject[] DropInstanceList = new GameObject[MaxDropsInGame];
    // Use this for initialization

    public void DropItemAtLocation(Vector3 location, GameObject drop)
    {
       GameObject go = Instantiate(drop, location, Quaternion.Euler(Vector3.zero)) as GameObject;
      // AllDropsOnMap.a
    }

    public void DropItemsFromList(Transform location, Drops list)
    {


        float radius = 2.0f;
        int count = list.totalDropsInList;
        Debug.Log(count);

        if (count == 1)
        {

        }
        else
        {
           
            DropListEntry de = list.List[0];
            if(de.dropChance == 1.0f)
            {
                DropItemAtLocation(location.position, DropInstanceList[de.index]);
            }

        }
    } 

    void Start () {

        instance = this;
        GameObject go =   DropInstanceList[0] = (GameObject)Resources.Load("Prefabs/Drops/GemPrefab");
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
