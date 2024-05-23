using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;
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
        else if (collision.collider.tag == "Bonus")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnGUI()
    {
        string timerText = "½Ã°£ : " + curTime;
        Rect textPos = new Rect(250, 250, 300, 60);
        GUI.Label(textPos, timerText, style);
    }
}
