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

        CheckIfInteractable();
    }

    private void CheckIfInteractable()
    {
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
        {
            rayColor = Color.green;

            CheckIfTool();
        }
        else
        {
            rayColor = Color.red;

            ClearHighlight();
        }
    }

    private void CheckIfTool()
    {
        if (hit.collider.CompareTag("Tools"))
        {
            if (toolPointedAt == null)
            {
                toolPointedAt = hit.collider;
                toolPointedAt.GetComponent<Highlightable>().Highlight();
            }
            else if (toolPointedAt.GetInstanceID() != hit.collider.GetInstanceID())
            {
                toolPointedAt.GetComponent<Highlightable>().UnHighlight();
                toolPointedAt = null;
            }
        }
    }
    private void ClearHighlight()
    {
        if (toolPointedAt != null)
        {
            toolPointedAt.GetComponent<Highlightable>().UnHighlight();
            toolPointedAt = null;
        }
    }
}
