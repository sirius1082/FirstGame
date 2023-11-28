using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyUi : MonoBehaviour
{
    public Text[] text;

    public static bool isChanged = false;
    void Start()
    {
        for(int i=0;i<text.Length; i++)
            text[i].text = KeySetting.keys[(KeyAction)i].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = KeySetting.keys[(KeyAction)i].ToString();
            }
            isChanged = false;
        }

    }
}
