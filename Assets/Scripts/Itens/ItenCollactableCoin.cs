using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenCollactableCoin : ItenCollactableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
}
