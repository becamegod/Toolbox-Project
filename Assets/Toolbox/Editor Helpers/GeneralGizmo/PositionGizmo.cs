using UnityEngine;

public class PositionGizmo : GeneralGizmo
{
    protected override void Draw()
    {
        Gizmos.color = Manager.color;
        Gizmos.DrawSphere(transform.position, Manager.sphereSize);
    }
}
