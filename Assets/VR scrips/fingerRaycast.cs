using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    private RaycastHit hit;
    private Collider toolPointedAt;
    private Color rayColor = Color.white;

    private void Update()
    {
        Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, rayColor);

        // If pointing at an interactable
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
        {
            rayColor = Color.green;

            // if TOOL
            if (hit.collider.CompareTag("Tools"))
            {
                if (toolPointedAt == null)
                {
                    toolPointedAt = hit.collider;
                    toolPointedAt.GetComponent<Highlightable>().Highlight();
                }
                else if (toolPointedAt != hit.collider)
                {
                    toolPointedAt.GetComponent<Highlightable>().UnHighlight();
                    toolPointedAt = null;
                }
            }
        }
        else
        {
            rayColor = Color.red;

            Clear();
        }
    }
    // Already made this a void for future reference.
    private void Clear()
    {
        // Unhighlight last tool pointed at if no longer pointing at any.
        if (toolPointedAt != null)
        {
            toolPointedAt.GetComponent<Highlightable>().UnHighlight();
            toolPointedAt = null;
        }
    }
}
