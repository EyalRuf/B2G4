using UnityEngine;
using System.Collections;

public class BoltSystem : MonoBehaviour
{
    public BoltSystemObj attachedObj;
    public Bolt bolt;

    public Transform anchorTransform;
    public GameObject objectPlaceholder;
    public float anchoringDistance;

    public void UseBolt()
    {
        attachedObj.isLockedInPlace = bolt.isClosed;
    }

    public void DetachObj()
    {
        attachedObj = null;
        bolt.canBolt = false;
        objectPlaceholder.SetActive(true);
    }

    public void AttachObj(BoltSystemObj obj)
    {
        attachedObj = obj;
        bolt.canBolt = true;
        objectPlaceholder.SetActive(false);
    }

    public void ObjectNoLongerHovering()
    {
        if (attachedObj == null)
            objectPlaceholder.SetActive(true);
    }

    public void ObjectHovering ()
    {
        if (attachedObj == null)
            objectPlaceholder.SetActive(false);
    }

    public bool IsSystemFunctional ()
    {
        return attachedObj != null && attachedObj.isObjectFunctional != false;
    }
}
