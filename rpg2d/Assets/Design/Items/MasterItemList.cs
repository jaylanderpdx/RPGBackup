using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public enum ItemTypes
{
    None,
    Currency,
    Weapon,
    Armor,
    Heart,
    Potion,
    Food

};

public enum WeaponUsage
{
Mainhand,
Offhand,
Twohand
};

public class MasterItemList : ScriptableObject {


    public static MasterItemList instance;
    public List<ItemDescription> items = new List<ItemDescription>();
    
  
    

    public static void AddItem(ItemDescription ItemToAdd)

    {

        instance.items.Add(ItemToAdd);
    }
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


[System.Serializable]
public class ItemDescription: ScriptableObject
{
    public ItemTypes type;
    public GameObject prefab;
    public string description;
    public string itemName;
}

[System.Serializable]
public class WeaponDescription: ItemDescription
{
   
    public int minDamage;
    public int maxDamage;
    public float attackSpeed;
    public WeaponUsage usage;
    public GameObject stats;

    [MenuItem("Assets/Create/RPG Items/Weapon")]
    public static void CreateAsset()
    {
        WeaponDescription desc = ScriptableObjectUtil.CreateAsset<WeaponDescription>();
        desc.type = ItemTypes.Weapon;
    }
}

[System.Serializable]
public class PotionDescription : ItemDescription
{

    public int AmountRestored;

    [MenuItem("Assets/Create/RPG Items/Basic Potion")]
    public static void CreateAsset()
    {
        PotionDescription desc = ScriptableObjectUtil.CreateAsset<PotionDescription>();
        desc.type = ItemTypes.Potion;
    }
}

