using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    private new AudioSource audio;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.explosionSound;
        this.audio.loop = false;
    }

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
            this.audio.Play();
            Destroy(collision.gameObject);
            GetComponentInChildren<Bomb>().setActiveBool();
            Destroy(gameObject, 1.0f);
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
