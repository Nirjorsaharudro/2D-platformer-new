using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New consumable")]
public class ConsumableClass : Item
{
    [Header("Consumable")] //data specific for consumable
    public float healthAdded;

    public override Item GetItem(){ return this;}
    public override ToolClass GetTool(){ return null;}
    public override MiscClass GetMisc(){ return null;}
    public override ConsumableClass GetConsumable(){ return this;}
}