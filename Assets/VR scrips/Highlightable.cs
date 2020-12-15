using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    private Material objectMaterial;
    private Color originalColor;

    public Color highlightColor = Color.yellow;

    private void Awake()
    {
        objectMaterial = GetComponent<Renderer>().material;
        originalColor = objectMaterial.color;
    }

    public void Highlight()
    {
        objectMaterial.color = highlightColor;
    }
    public void UnHighlight()
    {
        objectMaterial.color = originalColor;
    }
}
