using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingerRaycast : MonoBehaviour
{
    public GameObject startPoint;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //direction = endPoint.transform.position - startPoint.transform.position;
        Debug.DrawRay(startPoint.transform.position, startPoint.transform.forward, Color.green);
    }
}
