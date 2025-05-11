using System;
using UnityEngine;

public class ParticleSystemCallback : MonoBehaviour
{
    public event Action OnStopped;
    public event Action OnTriggered;
    public event Action<GameObject> OnCollided;

    private void OnParticleSystemStopped() => OnStopped?.Invoke();
    private void OnParticleCollision(GameObject other) => OnCollided?.Invoke(other);
    private void OnParticleTrigger() => OnTriggered?.Invoke();
}
