using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindowBox: MonoBehaviour
{
    public System.Action OnBoxOpened;
    public System.Action OnBoxClosed;


    public abstract void OpenBox(object obj);

    public abstract void CloseBox();

}

public class WindowStack : Singletone<WindowStack>
{
    private Stack<WindowBox> windowBoxes;

    [SerializeField]
    private RectTransform boxParent;

    public void Awake()
    {
        windowBoxes = new Stack<WindowBox>();
    }

    public void PushWindow(WindowBox box, object data)
    {
        if (!boxParent.gameObject.activeSelf) boxParent.gameObject.SetActive(true);

        box.transform.SetParent(boxParent);
        box.transform.SetAsLastSibling();
        box.GetComponent<RectTransform>().anchorMax = Vector3.one;
        box.GetComponent<RectTransform>().anchorMin = Vector3.zero;
        windowBoxes.Push(box);
        box.gameObject.SetActive(true);
        box.transform.localScale = Vector3.one;
        box.transform.localPosition = Vector3.zero;
        box.OpenBox(data);
    }

    public void OnBackButtonPressed()
    {
        if (windowBoxes.Count > 0)
        {
            var box = windowBoxes.Pop();
            box.CloseBox();
            Destroy(box.gameObject);
        }
        else
        {
            boxParent.gameObject.SetActive(false);
        }
    }

    public void CloseWindow(WindowBox box)
    {
        if (windowBoxes.Peek() == box)
        {
            OnBackButtonPressed();
        }
    }
}
