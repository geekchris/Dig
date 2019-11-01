using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    public int vertSpeed = 2;
    CameraShake camShake;

    private ChargeMeter chargeMeter;
    public bool isBoosting;
    void Start()
    {
        /**GameObject gm = GameObject.FindWithTag("GameMaster");
        *if(gm != null)
        *{
        *   camShake = gm.GetComponent<CameraShake>();
        }**/
        chargeMeter = GameObject.Find("Charge Meter").GetComponent<ChargeMeter>();
        vertSpeed = 2;
        isBoosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosting)
        {
            Debug.Log("in here");
            vertSpeed = 5;
        }
        transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().invincible == false)//&& other.GetComponent<Player>().tookDamage == false)
        {
            //other.GetComponent<Player>().health -= damage;
            //other.GetComponent<Player>().tookDamage = true;
            //camShake.Shake(0.1f, 0.2f);
            //chargeMeter.IncrementProgress(0.1f);
            chargeMeter.IncrementProgress(1.0f);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player") && other.GetComponent<Player>().invincible == true)
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
