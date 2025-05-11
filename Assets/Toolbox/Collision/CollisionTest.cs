using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] CollisionCallback callback;

    private void Reset() => callback = GetComponent<CollisionCallback>();

    private void OnEnable() => callback.OnEntered += OnEntered;

    private void OnDisable() => callback.OnEntered -= OnEntered;

    private void OnEntered(BaseCollider other) => Debug.Log($"Collided with {other.Transform.name}");
}
