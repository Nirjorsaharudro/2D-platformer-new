using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Misc")]
public class MiscClass : Item
{
    //data specific for misc
    public override Item GetItem(){ return this;}
    public override ToolClass GetTool(){ return null;}
    public override MiscClass GetMisc(){ return this;}
    public override ConsumableClass GetConsumable(){ return null;}
}
