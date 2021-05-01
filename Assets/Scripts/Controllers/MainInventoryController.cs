using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MainInventoryController : MonoBehaviour
{
    public ItemList startingItems;

    [SerializeField] private PlayerInventoryList inventoryList;
    
    void Start()
    {





    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    foreach (var item in inventoryList.getValue().getListRaw())
        //    {
        //        print(item.itemName);
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    inventoryList.getValue().AddList(startingItems);
        //}
    }
}
