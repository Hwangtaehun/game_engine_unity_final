using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject obsPrefab;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private float interval;

    void Start()
    {
        StartCoroutine(CreateWall());
    }

    IEnumerator CreateWall()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);

        while (true)
        {
            Instantiate(wallPrefab, transform.position, transform.rotation);
            yield return wait;
        }
    }
}
