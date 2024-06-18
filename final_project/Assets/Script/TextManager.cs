using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Toggle maintoggle;
    private bool click;

    private void Awake()
    {
        click = maintoggle.isOn;
    }

    public void ToggleController()
    {
        click = !click;
        maintoggle.isOn = click;
    }
}
