using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleBar : MonoBehaviour
{
    public Image fullScale;
    public Image currentScale;

    long currentValue;
    long currentMax;

    public TextMeshProUGUI text;


    public void updateScale(long value, long max)
    {
        float scale = (float)max / (float)value;

        RectTransform full = fullScale.rectTransform;
        RectTransform current = currentScale.rectTransform;

        current.sizeDelta = new Vector2(full.rect.width * scale, full.rect.height);

        currentMax = max;
        currentValue = value;

        text.text = currentValue + " / " + currentMax;
       
    }
}
