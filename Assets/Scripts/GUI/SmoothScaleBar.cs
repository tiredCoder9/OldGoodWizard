using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothScaleBar : MonoBehaviour
{
    [SerializeField]
    RectTransform maxScale;
    [SerializeField]
    RectTransform currentScale;

    [SerializeField]
    int framesCount=40;

    private float scaleValue;

    private bool IsScaling;

    public void SetScaleSmooth(float scale)
    {
       
        if (IsScaling)
        {
            StopCoroutine(scaleBarAnimation(scale));
            IsScaling = false;
            SetScale(scaleValue);
        }

        scaleValue = scale;
        StartCoroutine(scaleBarAnimation(scale));

    }

    public void SetScale(float scale)
    {
        scaleValue = scale;
        float max = maxScale.rect.width;
        Vector2 size = currentScale.sizeDelta;
        currentScale.sizeDelta = new Vector2(max * scale, size.y);
        print(max * scale);
    }

    private IEnumerator scaleBarAnimation(float targetScale)
    {
        IsScaling = true;
        float max = maxScale.rect.width;
        Vector2 size = currentScale.sizeDelta;
        float sc = currentScale.sizeDelta.x/ max;

        float dd = (targetScale - sc)/ framesCount;

        for(int i=0; i< framesCount; i++)
        {
            sc += dd;
            currentScale.sizeDelta = new Vector2(max * sc, size.y);
            yield return null;
            if (!IsScaling)
            {
                currentScale.sizeDelta = new Vector2(max * scaleValue, size.y);
                break;
            }
        }
        currentScale.sizeDelta = new Vector2(max * scaleValue, size.y);
        IsScaling = false;
        
    }
}
