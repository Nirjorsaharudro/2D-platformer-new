using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();
    public int inventorySpace = 1;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject panelNotEnounghSpace;
    public Toggle enableRemove;

    public InventoryItemController[] InventoryItems;

    private void Awake() {
        //for singleton desgin pattern
        instance = this;
    } 
    
    //Adding items to the list
    public void Add(Item item){
        //Debug.Log(Items.Count);
        if(inventorySpace>Items.Count){
            Items.Add(item);
        }else{
            panelNotEnounghSpace.SetActive(true);
        }
        
    }
    
    //Removing items to the list
    public void Remove(Item item){
        Items.Remove(item);
    }
    
    //displaying items in the inventory
    public void ListItems(){
        //Clean inventory before calling inventoryButton
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if(enableRemove.isOn)
                removeButton.gameObject.SetActive(true);
        }

        SetInventoryItems();
    }

    //For toggle to remove item from the inventory
    public void EnableItemRemove(){
        if(enableRemove.isOn){
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }else{
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
    
    //After remove an item cleaning list
    public void SetInventoryItems(){
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
           InventoryItems[i].AddItem(Items[i]); 
        }
    }
}
