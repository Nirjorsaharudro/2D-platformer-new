using System.Collections;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public abstract class Item : ScriptableObject {
    [Header("Item")]
    // public enum Type
    // {
    //     healable,
    //     destructive,
    //     attack
    // }
    // public Type type;
    // public int id;
    //public int value;
    public string itemName;
    public Sprite icon;

    public abstract Item GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();
}

