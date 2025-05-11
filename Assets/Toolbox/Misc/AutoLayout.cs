using UnityEngine;

[ExecuteAlways]
public class AutoLayout : MonoBehaviour
{
    [SerializeField] protected Vector3 axis;
    [SerializeField] float distance = 1;
    [SerializeField] bool updateInEditMode = true;

    public int ChildCount => transform.childCount;
    public float Distance
    {
        get => distance;
        set
        {
            if (value == distance) return;
            distance = value;
            Arrange();
        }
    }

    private void Awake() => Arrange();

    private void OnValidate()
    {
        if (!Application.isPlaying && !updateInEditMode) return;
        Arrange();
    }

    private void OnTransformChildrenChanged() => OnValidate();

    private void Arrange()
    {
        var n = transform.childCount;
        var startOffset = (n % 2 == 1) ? (n / 2) * distance : (n / 2 - .5f) * distance;
        var position = axis * -startOffset;

        for (int i = 0; i < n; i++)
        {
            var child = transform.GetChild(i);
            child.localPosition = position;
            position += axis * distance;
        }
    }
}
