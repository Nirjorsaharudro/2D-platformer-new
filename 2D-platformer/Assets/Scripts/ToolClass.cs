using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/new Tool")]
public class ToolClass : Item
{
    [Header("Tool")]//data specific for tool class
    public ToolType toolType;

    public enum ToolType
    {
        weapon,
        pickaxe,
        hammer,
        axe
    }
    
    public override Item GetItem(){ return this;}
    public override ToolClass GetTool(){ return this;}
    public override MiscClass GetMisc(){ return null;}
    public override ConsumableClass GetConsumable(){ return null;}
}
