using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    private Text ToolTipText;
    private RectTransform ToolTipBackground;
    public float textPadding=1f;

    public Camera camera;
    public RectTransform canvasRect; 


    private void Awake()
    {
        //Singletone
        instance = this;

        ToolTipText = GameObject.Find("TooltipText").GetComponent<Text>();
        ToolTipBackground = GameObject.Find("TooltipBackground").GetComponent<RectTransform>();

        hideTooltip_st();
    }

    public void ShowTooltip(string _showedText)
    {
        gameObject.SetActive(true);
        ToolTipText.text = _showedText;
        Vector2 backgroundSize = new Vector2(ToolTipText.preferredWidth+ (textPadding*2), ToolTipText.preferredHeight+ (textPadding * 2));
        ToolTipBackground.sizeDelta = backgroundSize;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, camera, out localPoint);
        transform.localPosition = localPoint;
    }

    public static void showTooltip_st(string _showedText)
    {
        instance.ShowTooltip(_showedText);
    }

    public static void hideTooltip_st()
    {
        instance.HideTooltip();
    }

    
}
