﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    private int speed = 2;
    CameraShake camShake;

    private ChargeMeter chargeMeter;


    void Start()
    {
        /**GameObject gm = GameObject.FindWithTag("GameMaster");
        *if(gm != null)
        *{
        *   camShake = gm.GetComponent<CameraShake>();
        }**/
        chargeMeter = GameObject.Find("Charge Meter").GetComponent<ChargeMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//&& other.GetComponent<Player>().tookDamage == false)
        {
            //other.GetComponent<Player>().health -= damage;
            //other.GetComponent<Player>().tookDamage = true;
            //camShake.Shake(0.1f, 0.2f);
            chargeMeter.IncrementProgress(0.10f);
            Destroy(gameObject);
        }
        if(other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
