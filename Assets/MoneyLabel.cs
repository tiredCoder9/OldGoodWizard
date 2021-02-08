using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyLabel : MonoBehaviour
{
    public PlayerMoney money;
    public TextMeshProUGUI value;

    void Start()
    {
        value.text = money.getValue().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (money.IsDirty)
        {
            value.text = money.getValue().ToString();
        }
    }
}
