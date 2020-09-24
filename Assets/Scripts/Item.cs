using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Item")]
public class Item : ScriptableObject
{
    public byte id;
    public Sprite art;
    public new string name;
    [TextArea]
    public string description;
    public short cost = 1;
}
