using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction { JUMP, ATTACK, KEYCOUNT }
public static class KeySetting { public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); }

public class GameManager : MonoBehaviour
{
    private KeyCode[] defaultKeys = new KeyCode[] { KeyCode.LeftAlt, KeyCode.LeftControl };
    public static GameManager instance = null;

    [HideInInspector] public bool bMute = false;
    [HideInInspector] public float fBgm = -5.0f;
    [HideInInspector] public float fSfx = -10.0f;
    [HideInInspector] public float fJump = 10.0f;
    [HideInInspector] public bool bMouse = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }

        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }
}

//출처: https://ljhyunstory.tistory.com/282 [오늘도 열시미!:티스토리]