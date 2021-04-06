using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BoxElement<D> : WindowBox
{
    protected D lastData;

    public override void OpenBox(object obj)
    {
        if(obj is D)
        {
            lastData = (D)obj;
            OnOpen(lastData);
            OnBoxOpened?.Invoke();
        }
       
    }

    public override void CloseBox()
    {
        if (lastData!=null)
        {
            OnClose(lastData);
            OnBoxClosed?.Invoke();
        }
    }


    public abstract void OnOpen(D data);
    public abstract void OnClose(D data);

}

public class BoxGroup<T> : BoxElement<T>
{
    
    public bool IsOpen;
    public UnityEvent OnBoxClose;
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
        OnBoxClose.RemoveAllListeners();
    }
}
