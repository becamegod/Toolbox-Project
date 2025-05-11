using UnityEngine;

public class GizmoManager : AutoSingleton<GizmoManager>
{
    public float sphereSize = .1f;
    public Color color = new(0, 0, 1, .5f);
}
