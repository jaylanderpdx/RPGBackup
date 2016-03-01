using UnityEngine;
using System.Collections;
using UnityEditor;

public class ItemListCreator : MonoBehaviour {

    // Use this for initialization


[MenuItem("Game Design/Tables/Create Master Item List")]
    public static void CreateMasterItemList()
    {
        MasterItemList masterItemList = ScriptableObject.CreateInstance<MasterItemList>();
        MasterItemList.instance = masterItemList;
        AssetDatabase.CreateAsset(masterItemList, "Assets/Resources/MasterItemList.asset");
        AssetDatabase.Refresh();
    }


    void Start()
    {


    }
	// Update is called once per frame
	void Update () {
	
	}


   
}
