using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    private Material objectMaterial;
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        objectMaterial = GetComponentInChildren<Renderer>().material;
        originalColor = objectMaterial.color;
    }

    public void Highlight()
    {
        outline.enabled = true;
        objectMaterial.color = highlightColor;

    }
    public void UnHighlight()
    {
        outline.enabled = false;

        objectMaterial.color = originalColor;
    }
}
