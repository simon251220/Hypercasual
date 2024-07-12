using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;
    public TextMeshProUGUI uiTextValue2;
    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
        uiTextValue2.text = soInt.value2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
        uiTextValue2.text = soInt.value2.ToString();
    }
}
