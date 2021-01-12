using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHighlightable : Highlightable
{
    public Button button;
    public Image image;

    private Color mainColor = Color.white;

    public override void Highlight()
    {
        image.color = Color.red;
    }

    public override void UnHighlight()
    {
        image.color = mainColor;
    }

    public override void Interact(Tool t)
    {
        print("This is UI!");

        button.onClick.Invoke();
    }
}
