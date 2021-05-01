using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JorneyResultView : MonoBehaviour
{
    public event System.Action OnClick;

    public abstract void SetValue(JorneyData data);

    public void OnCloseBtnClick()
    {
        OnClick?.Invoke();
    }
}
