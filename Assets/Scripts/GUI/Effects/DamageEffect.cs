using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamageEffect : MonoBehaviour
{
    [SerializeField]
    private Text value;
    [SerializeField]
    float fadingSpeed = 0.01f;

    private void Awake()
    {
        StartCoroutine(colorFade(value));
        Destroy(gameObject, 1.7f);
    }

    IEnumerator colorFade(Text text)
    {
        Color col = text.color;
        float alpha = col.a;

        Vector3 pos = transform.position;
        float valY = pos.y;
        while (true)
        {
            yield return null;
            if (alpha > 0)
            {

                text.color = new Color(col.r, col.g, col.g, alpha);
                transform.position = new Vector3(pos.x, valY, pos.z);
                alpha -= fadingSpeed;
                valY+= fadingSpeed;
                
            }
        }
    }

    public void SetValue(int val)
    {
        if(value!=null) value.text = val.ToString();
    }


}
