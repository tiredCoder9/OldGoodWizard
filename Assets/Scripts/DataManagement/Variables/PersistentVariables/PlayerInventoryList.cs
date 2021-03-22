using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

[CreateAssetMenu]
public class PlayerInventoryList : PersistentVariable<ItemList>
{


    public override BasePersistentVariableData getVariableData()
    {
        return new PersistentVariableData<ItemList>(value, name);
    }

    public override void loadVariableData(BasePersistentVariableData variableData)
    {
        if(variableData is PersistentVariableData<ItemList>)
        {
            var data = (PersistentVariableData<ItemList>)variableData;
            value = data.value;
        }
    }


  
}
