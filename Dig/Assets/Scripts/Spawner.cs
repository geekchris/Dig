using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject ant;
    public GameObject healthPack;
    public GameObject spider;
    public GameObject GM;
    private int currentlvl;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTime = 0.65f;

    private float antSpawnTime;
    public float max;

    private float spiderSpawnTime;
    private float spidermax;

    private float healthSpawnTime;
    private float healthmax;
    private float spawnFactor;
    public Transform player;
    public int level;

    public GameObject score;
    public string scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        max = GetComponent<MeshRenderer>().bounds.size.x / 2;
        antSpawnTime = 3;
        spiderSpawnTime = 3;
        healthSpawnTime = UnityEngine.Random.Range(20.0f, 30.0f);
        spawnFactor = 1.0f;
        obstacle.GetComponent<RockObstacle>().vertSpeed = 2;
        ant.GetComponent<AntObstacle>().vertSpeed = 2;
        healthPack.GetComponent<HealthPack>().vertSpeed = 2;

        obstacle.GetComponent<RockObstacle>().isBoosting = false;
        ant.GetComponent<AntObstacle>().isBoosting= false;
        healthPack.GetComponent<HealthPack>().isBoosting = false;

        currentlvl = GM.GetComponent<LevelTransition>().getCurrentLvl();
    }

    // Update is called once per frame

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-max + 0.5f, max -0.5f), transform.position.y, transform.position.z);
            GameObject newRock = Instantiate(obstacle, position, Quaternion.identity);
            timeBtwSpawn = UnityEngine.Random.Range(2.5f, 3.0f);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(antSpawnTime <= 0)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            GameObject newAnt = Instantiate(ant, position, Quaternion.identity);
            antSpawnTime = UnityEngine.Random.Range(5.0f, 10.0f);
        }
        else
        {
            antSpawnTime -= Time.deltaTime;
        }

        if (healthSpawnTime <= 0 && player.GetComponent<Player>().health < 3)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
            GameObject newHealth = Instantiate(healthPack, position, Quaternion.identity);
            healthSpawnTime = UnityEngine.Random.Range(20.0f, 60.0f) * spawnFactor;
        }
        else if (player.GetComponent<Player>().health < 3)
        {
            healthSpawnTime -= Time.deltaTime;
        }

        if(currentlvl == 2)
        {
            if (spiderSpawnTime <= 0)
            {
                Vector3 position = new Vector3(UnityEngine.Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
                GameObject newSpider = Instantiate(spider, position, Quaternion.identity);
                scoreText = score.GetComponent<Score>().scoreText.text.Trim('m');
                if(Int32.Parse(scoreText) > 300)
                {
                    waiter();
                    Vector3 position2 = new Vector3(UnityEngine.Random.Range(-max + 0.5f, max - 0.5f), transform.position.y, transform.position.z);
                    GameObject newSpider2 = Instantiate(spider, position2, Quaternion.identity);
                }
                spiderSpawnTime = UnityEngine.Random.Range(15.0f, 20.0f);
            }
            else
            {
                spiderSpawnTime -= Time.deltaTime;
            }
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
