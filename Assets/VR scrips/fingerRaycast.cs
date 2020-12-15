using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    public float pointerStartWidth = 0.025f;
    public float pointerEndWidth = 0.0125f;
    public float pointerDistance = 2f;
    public Color idlePointerColor = Color.blue;
    public Color pointerSelectColor = Color.green;

    private RaycastHit hit;
    private Vector3 pointerEnd;
    private Collider pointingAtInteractable;
    private LineRenderer pointingLine;

    private void Awake()
    {
        pointingLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        CheckIfInteractable();
        PointingLine();
    }

    private void CheckIfInteractable()
    {
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
        {
            if (hit.distance < pointerDistance)
            {
                SelectInteractable();
            }
        }
        else
        {
            ClearHighlight();
            pointingAtInteractable = null;
        }
    }

    private void PointingLine()
    {
        // Check what the player is pointing at > > Change line color and endPos accordingly
        if (pointingAtInteractable)
        {
            // Snap pointer-end to interactable object
            pointerEnd = pointingAtInteractable.transform.position;
            // Line Color
            pointingLine.material.color = pointerSelectColor;
        }
        else
        {
            pointerEnd = startPoint.transform.position + transform.TransformDirection(Vector3.forward) * pointerDistance;
            // Line Color
            pointingLine.material.color = idlePointerColor;
        }
        // Line StartPos
        pointingLine.SetPosition(0, startPoint.transform.position);
        // Line EndPos
        pointingLine.SetPosition(1, pointerEnd);
    }

    private void SelectInteractable()
    {
        // The assumption is that every Interactable will highlight. Else this code returns an error!
        if (pointingAtInteractable == null)
        {
            pointingAtInteractable = hit.collider;
            pointingAtInteractable.GetComponent<Highlightable>().Highlight();
        }
        else if (pointingAtInteractable.GetInstanceID() != hit.collider.GetInstanceID())
        {
            pointingAtInteractable.GetComponent<Highlightable>().UnHighlight();
            pointingAtInteractable = null;
        }
    }
    private void ClearHighlight()
    {
        if (pointingAtInteractable != null)
        {
            if (pointingAtInteractable.TryGetComponent(out Highlightable highlightAble))
            {
                highlightAble.UnHighlight();
            }
        }
    }

}
