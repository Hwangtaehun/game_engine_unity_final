using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private AudioClip bonusSound;
    private Camera m_camera;
    private new AudioSource audio;
    private Animator animator;
    private float curTime = 0.0f;

    void Start()
    {
        m_camera = Camera.main;
        jumpPower = GameManager.instance.fJump;
        animator = GetComponentInChildren<Animator>();
        this.audio = GetComponent<AudioSource>();
        this.audio.clip = this.bonusSound;
        this.audio.loop = false;
        timeText.transform.position = transform.position;
    }

    void Update()
    {
        curTime += Time.deltaTime;
        timeText.text = "time : " + curTime.ToString("F2");
        timeText.transform.position = m_camera.WorldToScreenPoint(transform.position + new Vector3(0, 2.0f, 0));

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Attack", true);
            GetComponentInChildren<BulletGenerator>().Shooting();
            Invoke("attackstop", 0.5f);
        }

        if (Input.GetMouseButtonDown(2))
        {
            gameManager.GetComponent<ButtonManager>().ControllerOption();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Wall")
        {
            //SceneManager.LoadScene("Play");
            gameManager.GetComponent<UIManager>().Gameover();
        }
        else if (collision.collider.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<UIManager>().ChangeScore(5);
            this.audio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pass")
        {
            gameManager.GetComponent<UIManager>().ChangeScore(5);
        }
    }

    void attackstop()
    {
        animator.SetBool("Attack", false);
    }

    public float getTime()
    {
        return curTime;
    }

    public void setJump(float jump)
    {
        jumpPower = jump;
    }
}
