using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(startPoint.transform.position, startPoint.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider || hit.rigidbody)
            {
                Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.green);
            }
            Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.yellow);
            Debug.Log(hit.collider);
        }
        else
        {
            Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.red);
        }
    }
}
