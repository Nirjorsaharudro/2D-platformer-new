using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<slotClass> ItemsInfo = new List<slotClass>();
    public List<GameObject> InventoryTileObjects = new List<GameObject>();
    public int inventorySpace = 1;
    public int countDrop = 0;
    private int Max;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject panelNotEnounghSpace;
    public GameObject panelDropItem;
    public Text DropText;
    public Toggle enableRemove;
    public slotClass dropSlot;
    private ColorBlock theColor;
    //public GameObject firstSelectedItem;
    //public int[] values = new int[100];
    
    
    //public InventoryItemController[] InventoryItems;

    private void Awake() 
    {
        //for singleton desgin pattern
        instance = this;
    }
    
    //Adding ItemsInfo to the list
    public void Add(Item item)
    {
        //Debug.Log(ItemsInfo.Count);
        if(inventorySpace>ItemsInfo.Count){
            //check if inventory contains the item
            slotClass slot = contains(item);
            if(slot != null){
                slot.AddQuantity(1);
            } 
            else
            {
                ItemsInfo.Add(new slotClass(item, 1));
            }
            //ItemsInfo.Add(item);
        }else{
            panelNotEnounghSpace.SetActive(true);
        }
        
    }
    
    //Removing ItemsInfo to the list
    public void Remove(Item item)
    {
        slotClass temp = contains(item);
        dropSlot = temp;
        if(temp != null)
        {
            //Debug.Log(temp.GetQuantity());
            if(temp.GetQuantity() > 1)
            {
                panelDropItem.SetActive(true);
                Max = temp.GetQuantity();
                
                //temp.SubQuantity(countDrop);
            }
            else{
                slotClass slotToRemove = new slotClass();
                foreach (var slot in ItemsInfo)
                {
                    if(slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                Debug.Log(slotToRemove);
                ItemsInfo.Remove(slotToRemove);
                panelDropItem.SetActive(false);
                //return true;
            }   
            }
            //ListItems(); 
            //return false;   
    }
    
    //displaying ItemsInfo in the inventory
    public void ListItems()
    {
        //Clean inventory before calling inventoryButton
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
            InventoryTileObjects.Clear();
        }
        
        foreach (var item in ItemsInfo)
        {
            GameObject obj = Instantiate(InventoryItem,ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var quantity = obj.transform.Find("quantity").GetComponent<Text>();

            itemName.text = item.GetItem().itemName;
            itemIcon.sprite = item.GetItem().icon;
            quantity.text = item.GetQuantity().ToString();
            if(obj != null)
                InventoryTileObjects.Add(obj);
            if(enableRemove.isOn)
                removeButton.gameObject.SetActive(true);
        }
        
        StartCoroutine(selectItem(InventoryTileObjects[0]));
       // SetInventoryItems();
    }

    public void selection(){
        StartCoroutine(selectItem(InventoryTileObjects[0]));
    }
    
    //For item selection
    public IEnumerator selectItem(GameObject SelectedItem){
        yield return new WaitForSeconds(0.01f);
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        //clear selected obj;
        EventSystem.current.SetSelectedGameObject(null);
        //set selected item
        EventSystem.current.SetSelectedGameObject(SelectedItem);
        Debug.Log(SelectedItem);
    }

    //For toggle to remove item from the inventory
    public void EnableItemRemove()
    {
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
    // public void SetInventoryItems()
    // {
    //     //InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
    //     InventoryItems = new InventoryItemController[10];

    //     for (int i = 0; i < ItemsInfo.Count; i++)
    //     {
    //       for(int j = 0;j<ItemsInfo[i].GetQuantity();j++)
    //       {
    //         InventoryItems[i+j].AddItem(ItemsInfo[i].GetItem());
    //       }
            
    //     }
    // }

    public slotClass contains(Item item)
    {
        foreach (slotClass slot in ItemsInfo)
        {
            if(slot.GetItem() == item){
                //Debug.Log(slot);
                return slot;
            }
        }

        return null;
    }

    public void increaseDropItem(){
        if(countDrop < Max){
           countDrop += 1;
           DropText.text = countDrop.ToString();
        }
    }
    public void decreaseDropItem(){
        Debug.Log(countDrop);
        if(countDrop > 0){
           Debug.Log(countDrop);
           countDrop -= 1;
           DropText.text = countDrop.ToString();
        }
    }

}
