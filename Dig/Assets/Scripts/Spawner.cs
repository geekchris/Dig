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
    private float spawnFactor;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

        max = GetComponent<MeshRenderer>().bounds.size.x / 2;
        antSpawnTime = 3;
        healthSpawnTime = Random.Range(20.0f, 30.0f);
        spawnFactor = 1.0f;
        obstacle.GetComponent<RockObstacle>().vertSpeed = 2;
        ant.GetComponent<AntObstacle>().vertSpeed = 2;
        healthPack.GetComponent<HealthPack>().vertSpeed = 2;

        obstacle.GetComponent<RockObstacle>().isBoosting = false;
        ant.GetComponent<AntObstacle>().isBoosting= false;
        healthPack.GetComponent<HealthPack>().isBoosting = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max -0.5f), transform.position.y, transform.position.z);
            GameObject newRock = Instantiate(obstacle, position, Quaternion.identity);
            timeBtwSpawn = Random.Range(2.5f, 3.0f);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(antSpawnTime <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            GameObject newAnt = Instantiate(ant, position, Quaternion.identity);
            antSpawnTime = Random.Range(5.0f, 10.0f);
        }
        else
        {
            antSpawnTime -= Time.deltaTime;
        }

        if (healthSpawnTime <= 0 && player.GetComponent<Player>().health < 3)
        {
            Vector3 position = new Vector3(Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            GameObject newHealth = Instantiate(healthPack, position, Quaternion.identity);
            healthSpawnTime = Random.Range(20.0f, 60.0f) * spawnFactor;
        }
        else if (player.GetComponent<Player>().health < 3)
        {
            healthSpawnTime -= Time.deltaTime;
        }
    }
}
