using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject obsPrefab;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private float interval;
    [SerializeField] private float range = 3.0f;

    void Start()
    {
        StartCoroutine(CreateWall());
    }

    IEnumerator CreateWall()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);

        while (true)
        {
            int random = Random.Range(0, 3);
            float wallPosY = Random.Range(-range, range);

            transform.position = new Vector3(transform.position.x, wallPosY, transform.position.z);
            Instantiate(wallPrefab, transform.position, transform.rotation);

            if (random == 0)
            {
                Instantiate(obsPrefab, transform.position, transform.rotation);
            }
            else if (random == 1)
            {
                Instantiate(bonusPrefab, transform.position, transform.rotation);
            }

            yield return wait;
        }
    }
}
