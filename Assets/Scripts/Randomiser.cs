using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{

    public static bool withChance(float chance)
    {
        if (chance > 100) chance = 100;
        int res = (int)Random.Range(1, 100 / chance);
        print("Dice with chance: " +chance+ " - "+ res);
        return res == 1;
    }

}
