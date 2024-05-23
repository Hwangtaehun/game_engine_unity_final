using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score + "Á¡";
    }

    public void ChangeScore(int num)
    {
        score += num;
    }
}
