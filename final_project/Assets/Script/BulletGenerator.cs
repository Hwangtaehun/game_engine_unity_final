using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private AudioClip ShootSound;
    private new AudioSource audio;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.ShootSound;
        this.audio.loop = false;
    }

    public void Shooting()
    {
        this.audio.Play();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().Shoot(speed);
    }
}
