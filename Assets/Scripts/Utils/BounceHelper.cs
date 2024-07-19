using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public float scaleDurationStart = .2f;
    public float scaleBounceStart = 1f;
    public Ease ease = Ease.OutBack;

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

    public void BounceStart()
    {
        transform.DOScale(scaleBounceStart, scaleDurationStart).SetEase(ease);
    }
}
