using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item Item;

   public void PickUp(){
    InventoryManager.instance.Add(Item);
    Destroy(gameObject);
    //For refresing everytime
    InventoryManager.instance.ListItems();
   }

   private void OnMouseDown() {
    PickUp();
   }
}
