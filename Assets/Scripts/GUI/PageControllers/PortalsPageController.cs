using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsPageController : ViewListGroup<AdventureModule, ViewElement_Selectable<AdventureModule>>, Page
{

    private JorneyStartBoxGroup jorneyStartBox;
    private GameObject jorneyBoxObject;

    public GameObject jorneyBoxPrefab;
    public Transform jorneyBoxParent;
    

    private void updatePage()
    {
       if(jorneyStartBox==null) createBox();
       List<AdventureModule> adventures = AdventureModuleStore.Instance.getCollection();
       updateGroup(adventures);
    }

   

    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        ViewElement_Selectable<AdventureModule> view = viewObject.GetComponent<ViewElement_Selectable<AdventureModule>>();

        view.OnClickEvent.AddListener(OnAdventureSelected);

        views.Add(view);
    }

    public void OnAdventureSelected(Id module)
    {
        if (module.IsInitialized)
        {
            AdventureModule adventureModule = AdventureModuleStore.Instance.getObject(module);
            if (module != null)
            {
                OnBoxOpen(adventureModule);
            }
        }
    }

    public void show()
    {
        updatePage();
    }

    public void hide()
    {
        
    }

    public void createBox()
    {
        if (jorneyStartBox == null)
        {
            jorneyBoxObject = Instantiate(jorneyBoxPrefab, jorneyBoxParent);
            jorneyStartBox = jorneyBoxObject.GetComponent<JorneyStartBoxGroup>();
            jorneyStartBox.OnBoxClosed.AddListener(OnBoxClose);
        }
    }

    public void OnBoxClose(AdventureModule data)
    {
        if(data!=null && jorneyStartBox.IsOpen)
        {
            CloseBox(data);
        }
    }

    public void OnBoxOpen(AdventureModule data)
    {
        if (data != null && !jorneyStartBox.IsOpen)
        {
            OpenBox(data);
        }
    }

    public void CloseBox(AdventureModule data)
    {
        jorneyStartBox.OnClose(data);
        jorneyBoxObject.SetActive(false);
    }

    public void OpenBox(AdventureModule data)
    {
        jorneyStartBox.OnOpen(data);
        jorneyBoxObject.SetActive(true);
    }
}
