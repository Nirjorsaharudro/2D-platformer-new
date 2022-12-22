using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item Item;

   public void PickUp(){
    InventoryManager.instance.Add(Item);
    Destroy(gameObject);

   }

   private void OnMouseDown() {
    PickUp();
   }
}
