using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
        isMute = GameManager.instance.bMute;
        bgmSlider.value = GameManager.instance.fBgm;
        sfxSlider.value = GameManager.instance.fSfx;
        jumpSlider.value = GameManager.instance.fJump;
        masterMixer.SetFloat("BGM", GameManager.instance.fBgm);
        masterMixer.SetFloat("SFX", GameManager.instance.fSfx);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null)
        {
            text.text = score + " point";
        }

        if (isOver)
        {
            this.gameObject.GetComponent<ButtonManager>().setOver();
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
            gmov_score.text = "score " + score + " point";
            gmov_time.text = "time " + player.GetComponent<Player>().getTime().ToString("F2") + "s";
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

    public void soundControl()
    {
        isMute = !isMute;
        GameManager.instance.bMute = isMute;
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

        GameManager.instance.fBgm = sound;
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

        GameManager.instance.fSfx = sound;
    }

    public void sliderJumpControl()
    {
        float value = jumpSlider.value;
        value = Mathf.Round(value);
        GameManager.instance.fJump = value;

        if(player != null)
        {
            player.GetComponent<Player>().setJump(value);
        }
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
