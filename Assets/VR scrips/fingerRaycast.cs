using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    private RaycastHit hit;
    private Collider objectPointedAt;
    private Color originalColor;
    private Color highlightColor = Color.yellow;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity))
        {
            // If it's a tool && you just started pointing at it.
            if (hit.collider.CompareTag("Tools") && hit.collider != objectPointedAt)
            {
                objectPointedAt = hit.collider;
                originalColor = hit.collider.GetComponent<Renderer>().material.color;

                objectPointedAt.GetComponent<Renderer>().material.color = highlightColor;

                Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.green);
            }

            // else if raycast no longer hits tool OR immediately switched to another tool without hitting not-a-tool
            else if (objectPointedAt != hit.collider)
            {
                objectPointedAt.GetComponent<Renderer>().material.color = originalColor;
                objectPointedAt = null;

                Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.red);
            }
        }
        /*gasgteag
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Tools") && hit.collider != newHitCollider)
            {
                newHitCollider = hit.collider;
                originalColor = hit.collider.GetComponent<Renderer>().material.color;

                newHitCollider.GetComponent<Renderer>().material.color = highlightColor;


                //Stores the original name
                if (hit.collider.name != newName)
                {
                    oldName = hit.collider.name;
                }
                //Stores the original color
                if (hit.collider.GetComponent<Renderer>().material.color != highlightColor)
                {
                    originalColor = hit.collider.GetComponent<Renderer>().material.color;
                }
                //Change the color
                hit.collider.GetComponent<Renderer>().material.color = highlightColor;
                //Change the color back
                hit.collider.GetComponent<Renderer>().material.color = originalColor;


                Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.green);
            }
            else if(hit.collider == newHitCollider)
            {
                newHitCollider.GetComponent<Renderer>().material.color = originalColor;
                Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.yellow);
                newHitCollider = null;
            }
        }
        else
        {
            Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.red);
        }
         */
    }
}
