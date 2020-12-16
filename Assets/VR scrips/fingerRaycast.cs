using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public float pointerStartWidth = 0.025f;
    public float pointerEndWidth = 0.0125f;
    public float pointerDistance = 2f;
    public Color idlePointerColor = Color.blue;
    public Color pointerSelectColor = Color.green;

    private RaycastHit hit;
    private Vector3 pointerEnd;
    private Collider pointingAtInteractable;
    private LineRenderer pointingLine;
    private OculusInput input;

    private void Awake()
    {
        pointingLine = GetComponent<LineRenderer>();
        input = GetComponent<OculusInput>();
    }

    private void Update()
    {
        PointingLine();
        CheckIfInteractable();
    }

    private void PointingLine()
    {
        // Check what the player is pointing at > > Change line color and endPos accordingly
        if (pointingAtInteractable)
        {
            // Snap pointer-end to the interactable object
            pointerEnd = pointingAtInteractable.transform.position;
            // Line Color confirms you're pointing at an interactable
            pointingLine.material.color = pointerSelectColor;
        }
        else
        {
            pointerEnd = transform.position + transform.TransformDirection(Vector3.forward) * pointerDistance;
            // Line Color
            pointingLine.material.color = idlePointerColor;
        }
        // Line StartPos
        pointingLine.SetPosition(0, transform.position);
        // Line EndPos
        pointingLine.SetPosition(1, pointerEnd);
    }

    private void CheckIfInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
        {
            // If interactable is within range
            if (hit.distance < pointerDistance)
            {
                if (pointingAtInteractable == null)
                {
                    pointingAtInteractable = hit.collider;
                    pointingAtInteractable.GetComponent<Highlightable>().Highlight();
                }
                // If you directly switched from interactable- to interactable without pointing at 'nothing'
                else if (pointingAtInteractable.GetInstanceID() != hit.collider.GetInstanceID())
                {
                    pointingAtInteractable.GetComponent<Highlightable>().UnHighlight();
                    pointingAtInteractable = null;
                }

                if (input.triggerPressed)
                {
                    print("triggered!");
                }
            }
            else
            {
                ClearHighlight();
                pointingAtInteractable = null;
            }
        }
        else
        {
            ClearHighlight();
            pointingAtInteractable = null;
        }
    }
    private void ClearHighlight()
    {
        if (pointingAtInteractable != null)
        {
            pointingAtInteractable.GetComponent<Highlightable>().UnHighlight();
        }
    }

}
