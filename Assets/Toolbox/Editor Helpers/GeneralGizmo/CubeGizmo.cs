using UnityEngine;

public class CubeGizmo : GeneralGizmo
{
    [SerializeField] Vector3 size = Vector3.one;

    protected override void Draw()
    {
        Gizmos.color = Manager.color;
        Gizmos.DrawCube(transform.position, size);
    }
}
