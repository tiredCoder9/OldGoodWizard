using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance;
    [SerializeField]
    private List<Item> items;

    void Awake()
    {
        if (Instance == null) Instance = this;
        items = new List<Item>();
    }


    /// <summary>
    /// Возвращает предмет из общего списка всех предметов. ID предмета соотвествует его индексу в массиве.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Item getItemById(byte _id)
    {
        return items.First(itm => itm.id == _id);
    }


    public Item getRandomItemWithCost(short _cost)
    {
        List<Item> _filteredItems = items.FindAll(itm => itm.cost==_cost);
        return _filteredItems[Random.Range(0, _filteredItems.Count)];
    }

    public Item getRandomItemWthCost(short _minCost, short _maxCost)
    {
        List<Item> _filteredItems = items.FindAll(itm => itm.cost <= _maxCost && itm.cost >= _minCost);
        return _filteredItems[Random.Range(0, _filteredItems.Count)];
    }

    


}
