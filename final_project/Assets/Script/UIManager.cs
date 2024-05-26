using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject soundOff;
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject manualPanel;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text gmov_score;
    [SerializeField] private TMP_Text gmov_time;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider jumpSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    private bool isManual;
    private bool isOver;
    private bool isMute;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        isManual = false;
        isOver = false;
        isMute = false;
        masterMixer.SetFloat("BGM", -5);
        masterMixer.SetFloat("SFX", -10);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score + "점";

        if (isOver)
        {
            this.gameObject.GetComponent<ButtonManager>().setOver();
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
            gmov_score.text = "점수 " + score + "점";
            gmov_time.text = "시간 " + player.GetComponent<Player>().getTime().ToString("F2") + "초";
        }

        if (isMute)
        {
            masterMixer.SetFloat("Master", -80);
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            masterMixer.SetFloat("Master", 0);
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }

        if (isManual)
        {
            manualPanel.SetActive(true);
        }
        else
        {
            manualPanel.SetActive(false);
        }
    }

    public void ChangeScore(int num)
    {
        score += num;
    }

    public void SoundOn()
    {
        isMute = false;
    }

    public void SoundOff()
    {
        isMute = true;
    }

    public void Mainlevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void sliderBGMControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40.0f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }

    public void sliderSFXControl()
    {
        float sound = sfxSlider.value;

        if (sound == -40.0f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", sound);
        }
    }

    public void sliderJumpControl()
    {
        float value = jumpSlider.value;
        value = Mathf.Round(value);
        player.GetComponent<Player>().setJump(value);
    }

    public void Gameover()
    {
        isOver = true;
    }

    public void controllerManual()
    {
        isManual = !isManual;
    }
}
