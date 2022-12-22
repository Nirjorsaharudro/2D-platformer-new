﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject {
    public enum Type
    {
        healable,
        destructive,
        attack
    }
    public Type type;
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
}
