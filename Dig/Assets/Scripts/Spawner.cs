using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject ant;
    public GameObject healthPack;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTime = 0.65f;

    private float antSpawnTime;
    private float max;

    private float healthSpawnTime;
    private float healthmax;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        max = GetComponent<MeshRenderer>().bounds.size.x / 2;
        antSpawnTime = 3;
        healthSpawnTime = 3;
        
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

        if(antSpawnTime <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            Instantiate(ant, position, Quaternion.identity);
            antSpawnTime = Random.Range(5.0f, 10.0f);
        }
        else
        {
            antSpawnTime -= Time.deltaTime;
        }

        if(healthSpawnTime <= 0 && player.GetComponent<Player>().health < 3)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            Instantiate(healthPack, position, Quaternion.identity);
            healthSpawnTime = Random.Range(3.0f, 3.0f);
        }
        else
        {
            healthSpawnTime -= Time.deltaTime;
        }
    }
}
