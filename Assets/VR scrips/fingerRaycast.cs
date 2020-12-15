using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    public float pointerStartWidth;
    public float pointerEndWidth;
    public float pointerDistance = 2f;
    public Color idlePointerColor = Color.blue;
    public Color pointingPointerColor = Color.green;

    private RaycastHit hit;
    private Collider toolPointedAt;
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
                CheckIfTool();
            }
        }
        else
        {
            ClearHighlight();
        }
    }
    private void PointingLine()
    {
        pointingLine.SetPosition(0, startPoint.transform.position);

        if (toolPointedAt == null)
        {
            pointingLine.SetPosition(1, startPoint.transform.position + transform.TransformDirection(Vector3.forward) * pointerDistance);

            pointingLine.material.color = idlePointerColor;
            pointerStartWidth = 0.005f;
            pointerEndWidth = 0.005f;
            pointingLine.startWidth = pointerStartWidth;
            pointingLine.endWidth = pointerEndWidth;
        }
    }
    private void PointingAtTool()
    {
        pointingLine.material.color = pointingPointerColor;

        pointerStartWidth = 0.01f;
        pointerEndWidth = 0.005f;

        pointingLine.startWidth = pointerStartWidth;
        pointingLine.endWidth = pointerEndWidth;

        pointingLine.SetPosition(1, toolPointedAt.transform.position);
    }
    private void CheckIfTool()
    {
        if (hit.collider.CompareTag("Tools"))
        {
            if (toolPointedAt == null)
            {
                toolPointedAt = hit.collider;
                PointingAtTool();
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
