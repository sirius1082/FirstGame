using KWJ.UI.MANAGER;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction { UP,DOWN,LEFT,RIGHT,JUMP,MENU,INVENTORY,ADD,OPEN,KEYCOUNT}
public static class KeySetting { public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); }
public class KeyManager : MonoBehaviour
{
    private static KeyManager instance;
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space,KeyCode.Escape,KeyCode.I,KeyCode.Tab,KeyCode.E };
    int key = -1;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }
    private void OnGUI()
    {
        KeyChange();
    }

    public void KeyChange()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey)
        {
            if (!IsKeyExist(keyEvent.keyCode))
            {

                KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
                key = -1;
                KeyUi.isChanged = true;
            }
        }
    }
    public void ChangeKey(int keyValue)
    {
        key = keyValue;
        Debug.Log(key);
    }

    /// <summary>
    /// 특정한 키가 존재하는지 확인합니다.
    /// </summary>
    /// <param name="checkKey">확인시킬 키를 전달합니다.</param>
    /// <returns>등록되어있는 키라면 true 를, 등록되지 않은 키라면 false 를 반환합니다.</returns>
    bool IsKeyExist(KeyCode checkKey)
    {
        // Dictionary 의 모든 요소를 확인하며, 등록된 키가 존재하는지 확인합니다.
        foreach (KeyValuePair<KeyAction, KeyCode> element in KeySetting.keys)
        {
            // 확인시킬 키와 동일한 키가 등록되어있다면
            if (element.Value == checkKey)
            {
                // 등록된 키가 존재합니다.
                return true;
            }
        }

        // 등록된 키가 존재하지 않습니다.
        return false;
    }

}
