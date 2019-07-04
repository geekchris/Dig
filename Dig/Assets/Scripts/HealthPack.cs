using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
    private int vertSpeed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
