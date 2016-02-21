using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum ItemTypes
{
    None,
    Collectible,
    Powerup,
    Weapon,
    Sword



};

namespace Inventory
{


    public class InventoryController : MonoBehaviour {

        // Use this for initialization

        Dictionary<ItemTypes, int> InventoryItems = new Dictionary<ItemTypes, int>();

        void Start() {

        }


        public void AddSingleItem (ItemTypes ItemToAdd)
        {
            AddItemOfQuantity(ItemToAdd, 1);

        }

        public void AddItemOfQuantity(ItemTypes ItemToAdd, int quantity)
        {

            int ItemAlreadyInInventory = InventoryItems[ItemToAdd];

            if  (ItemAlreadyInInventory != 0)
            {
                InventoryItems.Add(ItemToAdd, quantity);

            }
            else
                InventoryItems[ItemToAdd] += quantity;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
