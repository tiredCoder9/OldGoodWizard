using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image image;
    void Start()
    {
        setItem(item);
    }

    public void setItem (Item _item)
    {
        image.sprite = _item.art;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.showTooltip_st(item.name + "\n" + item.description);
        print("hi");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.hideTooltip_st();
    }
}
