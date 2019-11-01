using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
    public int vertSpeed = 2;
    public bool isBoosting = false;
    void Start()
    {
        vertSpeed = 2;
        isBoosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosting)
        {
            vertSpeed = 5;
        }
        transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Player>().health = 3;
            collider.GetComponent<Player>().justHealed = true;
            Destroy(gameObject);
        }
        if (collider.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
