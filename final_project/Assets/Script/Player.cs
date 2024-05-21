using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
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
}
