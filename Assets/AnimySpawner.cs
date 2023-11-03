using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimySpawner : MonoBehaviour
{
    public GameObject animy;
    public float spawnRate = 1;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAnimy();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnAnimy();
            timer = 0;
        }
    }

    void SpawnAnimy()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(animy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
