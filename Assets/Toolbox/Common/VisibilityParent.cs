using UnityEngine;

public abstract class VisibilityParent : MonoBehaviour, IShow, IHide
{
    public abstract void Show();
    public abstract void Hide();
}

public interface IShow
{
    public void Show();
}

public interface IHide
{
    public void Hide();
}