using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projeto.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI textMoedas;
    public TextMeshProUGUI textMoedasGreen;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        coins.value2 = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        textMoedas.text = coins.ToString();
    }

    public void AddCoinsGreen(int amount = 1)
    {
        coins.value2 += amount;
        textMoedasGreen.text = coins.value2.ToString();
    }
}
