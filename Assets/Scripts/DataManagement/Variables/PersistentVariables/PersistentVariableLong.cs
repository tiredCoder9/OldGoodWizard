using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Number", menuName = "ScriptableVariables/PersistentLong")]
public class PersistentVariableLong : PersistentVariable<long>
{
    public override BasePersistentVariableData getVariableData()
    {
        return new PersistentVariableData<long>(value, name);
    }

    public override void loadVariableData(BasePersistentVariableData variableData)
    {
        if (variableData is PersistentVariableData<long>)
        {
            var castData = (PersistentVariableData<long>)variableData;
            this.value = castData.value;
        }
    }
}
