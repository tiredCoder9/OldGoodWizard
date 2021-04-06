using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectorBoxList<T, D> : ViewListGroup<T, D> where D : ViewElement_Selectable<T> where T : Identifyable
{
    public GameObject boxPrefab;

    protected BoxGroup<T> currentBox;
    protected GameObject currentBoxObject;

    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<ViewElement_Selectable<T>>();
        view.OnClickEvent.AddListener(onViewClicked);
        views.Add((D)view);
    }

    protected abstract void onViewClicked(Id id);

    protected virtual void createBox()
    {
        if (currentBox == null)
        {
            currentBoxObject = Instantiate(boxPrefab);
            currentBox = currentBoxObject.GetComponent<BoxGroup<T>>();
            currentBox.OnBoxClose.AddListener(closeBox);
        }
    }

    protected virtual void openBox(T data)
    {
        if (currentBoxObject != null) closeBox();

        if (currentBoxObject == null)
        {
            createBox();
            WindowStack.Instance.PushWindow(currentBox, data);
        }
    }

    protected virtual void closeBox()
    {
        if (currentBoxObject != null)
        {
            currentBox.OnBoxClose.RemoveListener(closeBox);
            WindowStack.Instance.CloseWindow(currentBox);
        }
    }
}
