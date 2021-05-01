using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class ViewElement_Selectable<D> : ViewElement<D>, IPointerClickHandler where D: Identifyable
{
    public Id id;
    public UnityEvent<Id> OnClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        print(eventData.pointerClick.name);
        if (id.IsInitialized) OnClickEvent.Invoke(id);
    }

}
