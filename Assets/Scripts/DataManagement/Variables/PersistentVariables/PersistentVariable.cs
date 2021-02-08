using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePersistentVariable : ScriptableObject
{
    public enum VariableType {pstring, pint, pdouble};
    private VariableType type;
    protected bool isDirty=false;

    public bool IsDirty { get { return isDirty; } }

    public abstract void loadVariableData(BasePersistentVariableData variableData);

    public abstract BasePersistentVariableData getVariableData();

    public abstract void restoreDefaultValue();


    public void setDirty(bool _dirty)
    {
        isDirty = _dirty;
    }

}

public abstract class PersistentVariable<T> : BasePersistentVariable
{
    [SerializeField] protected T value;
    [SerializeField] protected T defaultValue;
    
    public virtual T getValue()
    {
        return value;
    }

    public virtual void setValue(T _value)
    {
        value = _value;
        isDirty = true;
    }

    public virtual T getDefaultValue()
    {
        return defaultValue;
    }

    public override void restoreDefaultValue()
    {
        value = defaultValue;
    }






}