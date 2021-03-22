using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewListGroup<T,D> : MonoBehaviour where D: ViewElement<T>
{

    public List<D> views;
    public Transform viewsParentTransform;

    public GameObject viewPrefab;


    public virtual void updateGroup(List<T> targetList)
    {
        if (views == null) views = new List<D>();
        
        if (views.Count != targetList.Count)
        {
            resizeGroup(targetList);
        }



        for (int i=0; i < views.Count; i++)
        {
            handleElement(targetList[i], views[i]);
        }
    }

    protected void resizeGroup(List<T> targetList)
    {
       
        if (targetList.Count < views.Count)
        {
            int size = views.Count - targetList.Count;
            for (int i = 0; i < size; i++)
            {
                deleteView();  
            }
        }
        else if (targetList.Count > views.Count)
        {
            int size = targetList.Count - views.Count;
            for (int i = size; i > 0; i--)
            {
                createView();
            }
        }
    }

    

    protected virtual void createView()
    { 
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        D view = viewObject.GetComponent<D>();
        views.Add(view);
    }


    protected virtual void deleteView()
    {
        var view = views[0];
        views.RemoveAt(0);
        Destroy(view.gameObject);
    }

    protected virtual void handleElement(T data, D viewElement)
    {
        viewElement.updateView(data);
    }
}



