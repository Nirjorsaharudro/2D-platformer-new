using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField]private Item[] item;
    public Transform realWorldPos;
    //Items must have to add in here
    public GameObject[] realWorldItem;
    public Button removeButton;
    public static string Name;

    public void RemoveItem(){
        //For Droping items into the real world
        var itemName = gameObject.transform.Find("ItemName").GetComponent<Text>();
        if(itemName.text == "Blue Coin"){
            Name = "Blue Coin";
            InventoryManager.instance.Remove(item[0]);
        }else if(itemName.text == "Coin"){
            Name = "Coin";
            InventoryManager.instance.Remove(item[1]);    
        }else if(itemName.text == "Atom"){
            Name = "Atom";
            InventoryManager.instance.Remove(item[2]);
        }
        if(InventoryManager.instance.dropSlot.GetQuantity() == 1){
            DropItem();
        }
        //Debug.Log(Name);
    }
    public void DropItem(){
        if(InventoryManager.instance.dropSlot != null){
            Debug.Log(Name);
            if(InventoryManager.instance.dropSlot.GetQuantity() > 1){
               if(InventoryManager.instance.countDrop == InventoryManager.instance.dropSlot.GetQuantity()){
                itemIntoRealWorld();
                InventoryManager.instance.dropSlot.SubQuantity(InventoryManager.instance.countDrop-1);
                InventoryManager.instance.Remove(InventoryManager.instance.dropSlot.GetItem());
                //InventoryManager.instance.dropSlot.SubQuantity(1);
               }
               else{
                InventoryManager.instance.dropSlot.SubQuantity(InventoryManager.instance.countDrop);
                itemIntoRealWorld();
               }  
               InventoryManager.instance.ListItems();       
            }
            else if(InventoryManager.instance.dropSlot.GetQuantity() == 1){
               InventoryManager.instance.dropSlot.SubQuantity(1);
               InventoryManager.instance.Remove(InventoryManager.instance.dropSlot.GetItem());
               InventoryManager.instance.ListItems();
               if(Name == "Blue Coin"){   
                    GameObject obj = Instantiate(realWorldItem[0], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);
                }else if(Name == "Coin"){
                    GameObject obj = Instantiate(realWorldItem[1], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);    
                }else if(Name == "Atom"){
                    GameObject obj = Instantiate(realWorldItem[2], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);
                } 
            }
        }
    }

    void itemIntoRealWorld(){
       
        if(InventoryManager.instance.countDrop>0){
            
            for(int i=0;i<InventoryManager.instance.countDrop;i++)
            {
                Debug.Log(Name);
               if(Name == "Blue Coin"){
                    
                    GameObject obj = Instantiate(realWorldItem[0], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);
                }else if(Name == "Coin"){
                    GameObject obj = Instantiate(realWorldItem[1], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);    
                }else if(Name == "Atom"){
                    GameObject obj = Instantiate(realWorldItem[2], realWorldPos.position + transform.TransformDirection(new Vector2(Random.Range(0f,3f),
                      Random.Range(0f,3f))),transform.rotation);
                } 
                //yield return new WaitForSeconds(0.000001f);
            }
        }
    }

    // public void AddItem(Item newItem){
    //     Debug.Log(item);
    //     item = newItem;
    // }
    
}
