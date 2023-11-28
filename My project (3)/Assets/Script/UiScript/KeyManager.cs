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
    /// Ư���� Ű�� �����ϴ��� Ȯ���մϴ�.
    /// </summary>
    /// <param name="checkKey">Ȯ�ν�ų Ű�� �����մϴ�.</param>
    /// <returns>��ϵǾ��ִ� Ű��� true ��, ��ϵ��� ���� Ű��� false �� ��ȯ�մϴ�.</returns>
    bool IsKeyExist(KeyCode checkKey)
    {
        // Dictionary �� ��� ��Ҹ� Ȯ���ϸ�, ��ϵ� Ű�� �����ϴ��� Ȯ���մϴ�.
        foreach (KeyValuePair<KeyAction, KeyCode> element in KeySetting.keys)
        {
            // Ȯ�ν�ų Ű�� ������ Ű�� ��ϵǾ��ִٸ�
            if (element.Value == checkKey)
            {
                // ��ϵ� Ű�� �����մϴ�.
                return true;
            }
        }

        // ��ϵ� Ű�� �������� �ʽ��ϴ�.
        return false;
    }

}
