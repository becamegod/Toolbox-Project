using System;
using UnityEngine;

public class MouseCallback : MonoBehaviour
{
    public event Action OnUpAsButton, OnDown, OnUp, OnEnter, OnExit, OnOver, OnDrag;

    private void OnMouseUpAsButton() => OnUpAsButton?.Invoke();
    private void OnMouseDown() => OnDown?.Invoke();
    private void OnMouseUp() => OnUp?.Invoke();
    private void OnMouseEnter() => OnEnter?.Invoke();
    private void OnMouseExit() => OnExit?.Invoke();
    private void OnMouseOver() => OnOver?.Invoke();
    private void OnMouseDrag() => OnDrag?.Invoke();
}
