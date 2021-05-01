using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Number", menuName = "ScriptableVariables/PersistentDouble")]
public class PersistentVariableDouble : PersistentVariable<double>
{
    public override BasePersistentVariableData getVariableData()
    {
        return new PersistentVariableData<double>(value, name);
    }

    public override void loadVariableData(BasePersistentVariableData variableData)
    {
        if (variableData is PersistentVariableData<double>)
        {
            var castData = (PersistentVariableData<double>)variableData;
            this.value = castData.value;
        }
    }
}
