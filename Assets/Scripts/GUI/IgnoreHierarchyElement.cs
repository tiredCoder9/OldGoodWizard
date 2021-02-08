using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreHierarchyElement : MonoBehaviour
{
    //держит данный элемент интерфейса в самом конце иерархии, гарантируя то, что он будет отрисовываться поверх всех остальных
    //элементов одного родителя

    private int sublingPosition = 0;

    private void OnEnable()
    {
        sublingPosition = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

}
