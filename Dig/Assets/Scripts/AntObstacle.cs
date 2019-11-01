using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    public int vertSpeed = 2;
    private int horSpeed = 2;
    private int direction = 0; //0 is going right, 1 is going left
    private Vector3 pos;
    private Vector3 velocity;
    private float playerRadius = 0.5f;
    CameraShake camShake;

    public bool isBoosting;
    void Start()
    {
        vertSpeed = 2;
        GameObject gm = GameObject.FindWithTag("GameMaster");
        if(gm != null)
        {
            camShake = gm.GetComponent<CameraShake>();
            if (camShake == null)
            {
                Debug.LogError("No camerashake ");
            }
        }

        isBoosting = false;
    }
    void Update()
    {
        if (isBoosting)
        {
            vertSpeed = 5;
        }
        transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
        pos = transform.position;
        if(direction == 0)
        {
            velocity = Vector3.right * horSpeed * Time.deltaTime;
        }
        else
        {
            velocity = Vector3.left * horSpeed * Time.deltaTime;    
        }
        pos += velocity;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x + playerRadius > widthOrtho)
        {
            pos.x = widthOrtho - playerRadius;
            direction = 1;
            transform.Rotate(180, 0, 180);
        }
        if (pos.x - playerRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + playerRadius;
            direction = 0;
            transform.Rotate(-180, 0, -180);
        }
        transform.position = pos;
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().tookDamage == false && other.GetComponent<Player>().invincible == false) 
        {
            other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().tookDamage = true;
            camShake.Shake(0.1f, 0.2f);
        }
        else if(other.CompareTag("Player") && other.GetComponent<Player>().tookDamage == false && other.GetComponent<Player>().invincible == true)
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
