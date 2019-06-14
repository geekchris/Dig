using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject ant;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTime = 0.65f;

    private float antSpawnTime;
    private float max;


    // Start is called before the first frame update
    void Start()
    {
        max = GetComponent<MeshRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max -0.5f), transform.position.y, transform.position.z);
            Instantiate(obstacle, position, Quaternion.identity);
            timeBtwSpawn = Random.Range(2.5f, 3.0f);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
