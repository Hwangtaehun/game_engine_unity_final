using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private AudioClip bonusSound;
    private new AudioSource audio;
    private string timerText;
    private Animator animator;
    private float curTime = 0.0f;
    GUIStyle style = new GUIStyle();

    void Start()
    {
        style.fontSize = 40;
        animator = GetComponentInChildren<Animator>();
        this.audio = GetComponent<AudioSource>();
        this.audio.clip = this.bonusSound;
        this.audio.loop = false;
    }

    void Update()
    {
        curTime += Time.deltaTime;

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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Wall")
        {
            SceneManager.LoadScene("Main");
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

    void OnGUI()
    {
        string timerText = "½Ã°£ : " + curTime;
        Rect textPos = new Rect(250, 250, 300, 60);
        GUI.Label(textPos, timerText, style);
    }

    void attackstop()
    {
        animator.SetBool("Attack", false);
    }
}
