using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemSortTab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemCategory itemCategory;
    [SerializeField] private InventoryPageController page;

    public Image background;
    public System.Action<ItemCategory> OnSelected;

    public ItemCategory GetCategory()
    {
        return itemCategory;
    }

    public void Select()
    {
        page.SelectCategory(itemCategory);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }
}
