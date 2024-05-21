using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x > 20.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle" || collision.collider.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(float speed)
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.right * speed;
    }
}
