using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsPageController : ViewListGroup<AdventureModule, ViewElement_Selectable<AdventureModule>>, Page
{

    public JorneyStartingController jorneyStartingController;

    private void updateAdventuresList()
    {
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
        jorneyStartingController.OnAdventureSelected(module);
    }

    public void show()
    {
        updateAdventuresList();
    }

    public void hide()
    {
        
    }
}
