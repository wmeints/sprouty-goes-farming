using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InteractableExtensions
{
    public static bool IsInteractable(this RaycastHit2D hit)
    {
        return hit.transform.GetComponent<Interactable>() != null;
    }

    public static void Interact(this RaycastHit2D hit)
    {
        var component = hit.transform.GetComponent<Interactable>();

        if (component != null)
        {
            component.Interact();
        }
    }
}