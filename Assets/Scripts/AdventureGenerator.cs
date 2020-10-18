using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureGenerator : MonoBehaviour
{
    public AdventureModule mainModule;

    public Adventure tropes;


    

    public Trope getNextTrope(JorneyData jorney)
    {
        return generateBattleTrope(jorney);
    }


    private Trope generateBattleTrope(JorneyData jorney)
    {
        long targetID = mainModule.battleTropes[Random.Range(0, mainModule.battleTropes.Length)].id;
        return TropeManager.getTropeById(targetID);
    }


    private void generateAdventure()
    {

    }

}
