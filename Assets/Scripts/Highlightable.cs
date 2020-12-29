using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public Outline outline;

    public void Highlight()
    {
        outline.enabled = true;

    }
    public void UnHighlight()
    {
        outline.enabled = false;
    }

    public virtual void Interact(Tool t)
    {
        Debug.Log("Interacted with a highlightable with a tool");
    }
}
