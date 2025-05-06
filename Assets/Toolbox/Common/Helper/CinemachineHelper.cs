#if CINEMACHINE
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;

using UnityEngine;
using Unity.Cinemachine;

public static class CinemachineHelper
{
    public static TweenerCore<float, float, FloatOptions> DOFOV(this CinemachineCamera vcam, float fov, float duration)
    {
        return DOTween.To(() => vcam.Lens.FieldOfView, x => vcam.Lens.FieldOfView = x, fov, duration);
    }
}
#endif