using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsPageController : SelectorBoxList<AdventureModule, ViewElement_Selectable<AdventureModule>>, Page
{

   
    private void updatePage()
    {

       List<AdventureModule> adventures = AdventureModuleStore.Instance.getCollection();
       updateGroup(adventures);
    }

   

    public void show()
    {
        updatePage();
    }

    public void hide()
    {
        if (currentBoxObject != null) closeBox();
    }

    protected override void onViewClicked(Id id)
    {
        if (id.IsInitialized)
        {
            AdventureModule adventureModule = AdventureModuleStore.Instance.getObject(id);
            if (adventureModule != null)
            {
                openBox(adventureModule);
            }
        }
    }

    //public void createBox()
    //{
    //    if (jorneyStartBox == null)
    //    {
    //        jorneyBoxObject = Instantiate(jorneyBoxPrefab, jorneyBoxParent);
    //        jorneyStartBox = jorneyBoxObject.GetComponent<JorneyStartBoxGroup>();
    //        jorneyStartBox.OnBoxClosed.AddListener(OnBoxClose);
    //    }
    //}

    //public void OnBoxClose(AdventureModule data)
    //{
    //    if(data!=null && jorneyStartBox.IsOpen)
    //    {
    //        CloseBox(data);
    //    }
    //}

    //public void OnBoxOpen(AdventureModule data)
    //{
    //    if (data != null && !jorneyStartBox.IsOpen)
    //    {
    //        OpenBox(data);
    //    }
    //}

    //public void CloseBox(AdventureModule data)
    //{
    //    jorneyStartBox.OnClose(data);
    //    jorneyBoxObject.SetActive(false);
    //}

    //public void OpenBox(AdventureModule data)
    //{
    //    jorneyStartBox.OnOpen(data);
    //    jorneyBoxObject.SetActive(true);
    //}
}
