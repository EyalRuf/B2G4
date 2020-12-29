using UnityEngine;
using System.Collections;

public class EmptyHands : MonoBehaviour, I_InteractableFinder
{
    public ToolInteractionRaycast tRaycast;

    public Highlightable FindInteractble()
    {
        return tRaycast.PerformRaycast();
    }

    public void ActivateHands()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateHands()
    {
        gameObject.SetActive(false);
    }
}
