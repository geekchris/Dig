using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public GameObject cloud;
    private float CloudSpawnTime;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTime = 0.65f;
    private float max;
    // Start is called before the first frame update
    void Start()
    {
        max = GetComponent<MeshRenderer>().bounds.size.y / 2;
        CloudSpawnTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
