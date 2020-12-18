using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

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
    public Transform pointerDirection;

    private Hand hand;
    public SteamVR_Action_Boolean trigger;

    private Interacting interactScript;

    private void Awake()
    {
        hand = GetComponent<Hand>();
        pointingLine = GetComponent<LineRenderer>();
        interactScript = GetComponent<Interacting>();
    }

    private void Update()
    {
        if (!interactScript.holdingObject) // if not holding an object
        {
            if (!pointingLine.enabled) // if pointingline is disabled, enable it.
            {
                pointingLine.enabled = true;
            }

            PointingLine();
            CheckIfInteractable();
        }
        else
        {
            pointingLine.enabled = false; // if holding object, disable pointingline.
        }

        if (pointingAtInteractable)
        {
            if (trigger.stateUp) // Interact when pressing trigger (trigger= when releasing)
            {
                interactScript.Interact(hand, pointingAtInteractable.gameObject);
                ClearHighlight();
            }
        }
    }

    private void PointingLine()
    {
        // Check what the player is pointing at > > Change line color and endPos accordingly
        if (pointingAtInteractable)
        {
            pointerEnd = pointingAtInteractable.transform.position; // Snap pointer-end to the interactable object

            pointingLine.material.color = pointerSelectColor; // Line Color confirms you're pointing at an interactable
        }
        else
        {
            pointerEnd = pointerDirection.position + pointerDirection.TransformDirection(Vector3.forward) * pointerDistance;
            pointingLine.material.color = idlePointerColor; // Idle line color
        }

        pointingLine.SetPosition(0, pointerDirection.position); // Line StartPos
        pointingLine.SetPosition(1, pointerEnd); // Line StartPos

    }

    private void CheckIfInteractable()
    {
        if (Physics.Raycast(pointerDirection.position, pointerDirection.TransformDirection(Vector3.forward) * pointerDistance, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
        {
            if (hit.distance < pointerDistance) // If interactable is within range

            {
                if (pointingAtInteractable == null)
                {
                    pointingAtInteractable = hit.collider;
                    pointingAtInteractable.GetComponentInParent<Highlightable>().Highlight();

                }

                // If you directly switched from interactable- to interactable without pointing at 'nothing'
                else if (pointingAtInteractable.GetInstanceID() != hit.collider.GetInstanceID())
                {
                    pointingAtInteractable.GetComponentInParent<Highlightable>().UnHighlight();
                    pointingAtInteractable = null;
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
            pointingAtInteractable.GetComponentInParent<Highlightable>().UnHighlight();
        }
    }
}
