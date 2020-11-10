using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabs;
    public TabButton selected;
    public List<GameObject> objectsToSwap;

    public Sprite tabIdle;
    public Sprite tabSelected;

    public void Subscribe(TabButton tab)
    {
        if (tabs == null)
        {
            tabs = new List<TabButton>();
        }

        tabs.Add(tab);
    }

    public void OnTabSelected(TabButton tab)
    {
        if (selected != null) selected.Deselect();

        selected = tab;
        selected.Select();

        ResetTabs();
        selected.background.sprite = tabSelected;

        int index = tab.transform.GetSiblingIndex();

        for(int i=0; i<objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void OnTabExit(TabButton tab)
    {

    }


    private void ResetTabs()
    {
        foreach(TabButton tab in tabs)
        {
            if(selected!=null && tab==selected) { continue; }
            tab.background.sprite = tabIdle;
        }
    }


}
