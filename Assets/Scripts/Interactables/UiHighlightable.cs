using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiHighlightable : Highlightable
{
    [Header("UI Highlightable")]
    public Button button;
    public Image image;
    public TextMeshProUGUI text;

    public Color mainColor;

    public override void Highlight()
    {
        text.color = highlightColor;
        text.fontStyle = FontStyles.Underline;
    }

    public override void UnHighlight()
    {
        text.color = mainColor;
        text.fontStyle = FontStyles.Normal;
    }

    public override void Interact(Tool t)
    {
        print("This is UI!");

        button.onClick.Invoke();
    }
}
