using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<String, Vector2> OnMOuseHover;
    public static Action OnMOuseLoseFocus;
    private void OnEnable()
    {
        OnMOuseHover += ShowTip;
        OnMOuseLoseFocus += HideTip;
    }
    private void OnDisable()
    {
        OnMOuseHover -= ShowTip;
        OnMOuseLoseFocus -= HideTip;
    }
    void Start()
    {
        HideTip();
    }
    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(mousePos.x + tipWindow.sizeDelta.x + 30f, mousePos.y);
    }
    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
}
