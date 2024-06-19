using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isPause;
    private bool isOver;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            if (isPause)
            {
                Time.timeScale = 0;
                panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                panel.SetActive(false);
            }
        }
    }

    public void ControllerOption()
    {
        isPause = !isPause;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LoadingSceneController.LoadScene("Play");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Play");
    }

    public void setOver()
    {
        isOver = true;
    }
}
