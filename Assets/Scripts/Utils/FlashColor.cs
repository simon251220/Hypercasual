using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    /*public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _CurrentTween;
    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if(_CurrentTween != null)
        {
            _CurrentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var s in spriteRenderers)
        {
            _CurrentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }*/
}
