using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippable 
{
    bool IsEquipped();
    Sprite getIcon();

    void Equip();
}
