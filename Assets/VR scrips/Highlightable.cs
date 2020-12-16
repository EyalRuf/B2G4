using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    private Material objectMaterial;
    private Color originalColor;
    private Outline outline;

    public Color highlightColor = Color.yellow;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        objectMaterial = GetComponent<Renderer>().material;
        originalColor = objectMaterial.color;
    }

    public void Highlight()
    {
/*        objectMaterial.color = highlightColor;
*/        outline.enabled = true;
    }
    public void UnHighlight()
    {
/*        objectMaterial.color = originalColor;
*/        outline.enabled = false;

    }
}
