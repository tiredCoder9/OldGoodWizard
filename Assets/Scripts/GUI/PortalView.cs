using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PortalView : ViewElement_Selectable<AdventureModule>
{

    public Image coverArt;
    public TextMeshProUGUI portalName;
    public TextMeshProUGUI portalDescription;
    public Button button;
    public SimpleUIAnimator animator;

    public override void updateView(AdventureModule data)
    {
        id = data.Id;
        portalName.text = data.Name;
        portalDescription.text = data.Description;
        animator.Play(data.portalIdle);
    }

    public void OnButtonClick()
    {
        OnClickEvent.Invoke(id);
    }
}
