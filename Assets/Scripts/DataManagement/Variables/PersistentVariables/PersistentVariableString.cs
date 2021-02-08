using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Number", menuName = "ScriptableVariables/PersistentString")]
public class PersistentVariableString : PersistentVariable<string>
{
    public override BasePersistentVariableData getVariableData()
    {
        return new PersistentVariableData<string>(value, name);
    }

    public override void loadVariableData(BasePersistentVariableData variableData)
    {
        if (variableData is PersistentVariableData<string>)
        {
            var castData = (PersistentVariableData<string>)variableData;
            this.value = castData.value;
        }
    }
}
