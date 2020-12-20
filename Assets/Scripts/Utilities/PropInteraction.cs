using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OculusInput))]
public class PropInteraction : MonoBehaviour
{
    public Transform holdingPos;
    public LayerMask holdingMask;
    public float holdingRadius;
    public Rigidbody holdingObject;

    private OculusInput input;
    private Vector3 relativePropPosition;
    private Quaternion originalPropRotation;

    private void Start()
    {
        input = GetComponent<OculusInput>();
    }

    private void Update()
    {
        if (input.triggerDown)
        {
            Collider[] propsInSphere = Physics.OverlapSphere(holdingPos.position, holdingRadius, holdingMask, QueryTriggerInteraction.Ignore);

            if(propsInSphere.Length > 0)
            {
                holdingObject = propsInSphere[0].GetComponent<Rigidbody>();
                relativePropPosition = holdingObject.position - holdingPos.position;
                originalPropRotation = holdingObject.rotation;
            }
        }

        if (input.triggerUp)
        {
            //add throwing velocity and let go
            holdingObject.AddForce(input.worldVelocity, ForceMode.VelocityChange);
            holdingObject.AddTorque(input.worldAngularVelocity, ForceMode.VelocityChange);
            holdingObject = null;
        }

        //move along with controller
        if (holdingObject != null)
        {
            holdingObject.MovePosition(holdingPos.position + relativePropPosition);
            holdingObject.MoveRotation(originalPropRotation * holdingPos.rotation);
        }
    }
}
