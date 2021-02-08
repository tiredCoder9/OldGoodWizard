using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewListGroup<T,D> : MonoBehaviour where D: ViewElement<T>
{

    protected List<D> views;
    public Transform viewsParentTransform;

    public GameObject viewPrefab;


    public virtual void updateGroup(List<T> targetList)
    {
        if (views == null) views = new List<D>();

        if (views.Count != targetList.Count)
        {
            resizeGroup(targetList);
        }
        
        for(int i=0; i < views.Count; i++)
        {
            views[i].updateView(targetList[i]);
        }
    }

    protected void resizeGroup(List<T> targetList)
    {
       
        if (targetList.Count < views.Count)
        {
            for (int i = 0; i < views.Count - targetList.Count; i++)
            {
                deleteView(i);  
            }
        }
        else if (targetList.Count > views.Count)
        {
            for (int i = targetList.Count - views.Count; i > 0; i--)
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


    protected virtual void deleteView(int i)
    {
        if (views.Count >= i)
        {
            var view = views[i];
            views.RemoveAt(i);
            Destroy(view.gameObject);
        }
    }
}



