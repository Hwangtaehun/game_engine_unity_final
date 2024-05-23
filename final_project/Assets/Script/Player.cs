using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private GameObject gameManager;
    private string timerText;
    private float curTime = 0.0f;
    GUIStyle style = new GUIStyle();

    void Start()
    {
        style.fontSize = 40;
        style.normal.textColor = Color.white;
    }

    void Update()
    {
        curTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Wall")
        {
            SceneManager.LoadScene("Main");
        }
        else if (collision.collider.tag == "Bonus" || collision.collider.tag == "Pass")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<UIManager>().ChangeScore(5);
        }
    }

    void OnGUI()
    {
        string timerText = "½Ã°£ : " + curTime;
        Rect textPos = new Rect(250, 250, 300, 60);
        GUI.Label(textPos, timerText, style);
    }
}
