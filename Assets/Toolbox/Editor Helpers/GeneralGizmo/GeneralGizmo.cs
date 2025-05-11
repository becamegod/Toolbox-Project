using UnityEngine;

public abstract class GeneralGizmo : MonoBehaviour
{
    [SerializeField] bool alwaysDraw = true;

    protected GizmoManager Manager => GizmoManager.Instance;

    private void OnDrawGizmos()
    {
        if (!enabled) return;
        if (alwaysDraw) Draw();
    }

    private void OnDrawGizmosSelected()
    {
        if (!enabled) return;
        if (!alwaysDraw) Draw();
    }

    protected abstract void Draw();
}
