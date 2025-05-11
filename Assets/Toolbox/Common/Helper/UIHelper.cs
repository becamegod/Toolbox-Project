using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public static class UIHelper
{
    /// Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement() => IsPointerOverUIElement(GetEventSystemRaycastResults());

    /// Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (var index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            var curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }

    /// Gets all event systen raycast results of current mouse or touch position.
    public static List<RaycastResult> GetEventSystemRaycastResults()
    {
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        var raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
