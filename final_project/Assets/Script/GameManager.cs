using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector] public bool bMute = false;
    [HideInInspector] public float fBgm = -5.0f;
    [HideInInspector] public float fSfx = -10.0f;
    [HideInInspector] public float fJump = 10.0f;

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
    }
}

//��ó: https://ljhyunstory.tistory.com/282 [���õ� ���ù�!:Ƽ���丮]