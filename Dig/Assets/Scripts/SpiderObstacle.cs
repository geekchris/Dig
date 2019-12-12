using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpiderObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    public int deploySpeed = 3;
    public float chaseSpeed = 2;
    public int wait = 3;
    public float counter = 0.0f;
    private float rotateSpeed = 5;
    public Player Doug;
    private float max;
    private float distance;
    public Vector3 deployPosition;
    private Vector3 velocity;
    private Vector2 direction;
    private bool isChasing;
    CameraShake camShake;
    void Start()
    {
        GameObject gm = GameObject.FindWithTag("GameMaster");
        if (gm != null)
        {
            camShake = gm.GetComponent<CameraShake>();
            if (camShake == null)
            {
                Debug.LogError("No camerashake ");
            }
        }
        max = 2.75f;
        Doug = GameObject.FindWithTag("Player").GetComponent<Player>();

        deployPosition = new Vector3(Random.Range(-max + 0.5f, max - 0.5f), Random.Range(-1.0f, 1.4f), transform.position.z);
        isChasing = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isChasing)
        {
            distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - deployPosition.x, 2) + Mathf.Pow(transform.position.y - deployPosition.y, 2));
        }
        if(distance >= 0.0006)
        {
            //Debug.Log("deploying");
            transform.position = Vector3.Lerp(transform.position, deployPosition, deploySpeed * Time.deltaTime);
        }
        else if((counter % 60) < wait)
        {
            //Debug.Log("waiting");
            isChasing = true;
            direction = Doug.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            counter += Time.deltaTime;
        }
        else
        {
            //Debug.Log("chasing");
            direction.Normalize();
            Vector3 velocity = new Vector3(direction.x, direction.y, 0) * chaseSpeed * Time.deltaTime;
            transform.position += velocity;
            Debug.Log(transform.position);
        }

        //if(isChasing && (transform.position.x >= 5 || transform.position.x <= -5 || transform.position.y >= 7 || transform.position.y <= 7))
        //{
        //    Destroy(gameObject);
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().tookDamage == false && other.GetComponent<Player>().invincible == false)
        {
            other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().tookDamage = true;
            camShake.Shake(0.1f, 0.2f);
        }
        else if (other.CompareTag("Player") && other.GetComponent<Player>().tookDamage == false && other.GetComponent<Player>().invincible == true)
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
