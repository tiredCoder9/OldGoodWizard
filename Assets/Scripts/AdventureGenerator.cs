using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureGenerator : MonoBehaviour
{
    public AdventureModule mainModule;

    public Adventure tropes;


    

    public Trope getNextTrope(Jorney jorney)
    {
        return generateBattleTrope(jorney);
    }


    private Trope generateBattleTrope(Jorney jorney)
    {
        return mainModule.battleTropes[Random.Range(0, mainModule.battleTropes.Length)];   
    }


    private void generateAdventure()
    {

    }

}
