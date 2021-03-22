using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BoxElement<D> :MonoBehaviour
{
    
    public abstract void OnOpen(D data);
    public abstract void OnClose(D data);

}

public class BoxGroup<T> : BoxElement<T>
{
    protected T lastData;
    public bool IsOpen;
    public UnityEvent<T> OnBoxClosed;
    [SerializeField] protected List<BoxElement<T>> boxElements;
    

    public override void OnOpen(T data)
    {
        foreach(var element in boxElements)
        {
            element.OnOpen(data);
        }
        IsOpen = true;
        lastData = data;
    }


    public override void OnClose(T data)
    {
        foreach(var element in boxElements)
        {
            element.OnClose(data);
        }
        IsOpen = false;
    }

    private void OnDestroy()
    {
        OnBoxClosed.RemoveAllListeners();
    }
}
