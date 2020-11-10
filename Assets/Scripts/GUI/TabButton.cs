using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public Image background;
    public TabGroup group;

    public UnityEvent selectEvent;
    public UnityEvent deselectEvent;

    private void Start()
    {
        background = GetComponent<Image>();
        group.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        group.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        group.OnTabExit(this);
    }

    public void Select()
    {
        if (selectEvent != null)
        {
            selectEvent.Invoke();
        }
    }

    public void Deselect()
    {
        if (deselectEvent != null)
        {
            deselectEvent.Invoke();
        }
    }

}
