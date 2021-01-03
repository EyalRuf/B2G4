using UnityEngine;
using System.Collections;

public class Bolt : Highlightable
{
    public bool isClosed;
    public bool canBolt;
    public GameObject boltClosedGO;
    public GameObject boltOpenGO;

    public override void Interact(Tool t)
    {
        if (canBolt)
        {
            isClosed = !isClosed;
            boltClosedGO.SetActive(true);
            boltOpenGO.SetActive(false);

            SendMessageUpwards("UseBolt", isClosed);
        }
    }
}
