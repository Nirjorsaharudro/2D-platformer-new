using System.Collections;
using UnityEngine;

[System.Serializable]
public class slotClass
{
   [SerializeField] private Item item;
   [SerializeField] private int quantity;
   [SerializeField] private float healthAdded;
   
   public slotClass()
   {
        item = null;
        quantity = 0;
        healthAdded = 0;
   }
   public slotClass(Item _item,int _quantity)
   {
        item = _item;
        quantity = _quantity;
        if(item.GetConsumable() != null)
          healthAdded = item.GetConsumable().healthAdded;
   }

   public Item GetItem() { return item;}
   public int GetQuantity() { return quantity;}
   public void AddQuantity(int _quantity){ quantity += _quantity;}
   public void SubQuantity(int _quantity)
   { 
    quantity -= _quantity;
    }
}
