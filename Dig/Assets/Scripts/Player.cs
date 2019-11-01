using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public bool tookDamage;
    public bool justHealed;
    public bool invincible;
    public Transform trasnform;
    private float timeLeft = 2.0f;
    // Start is called before the first frame update
    public GameObject gameOverUI;
    void Start()
    {
        health = 3;
        tookDamage = false;
        justHealed = false;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
            EndGame();
        }

        if(tookDamage == true)
        {
            timeLeft -= Time.deltaTime;
        }

        if(timeLeft < 0)
        {
            tookDamage = false;
            timeLeft = 2;
        }
    }
    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void turnInvincible()
    {
        invincible = true;
    }
    public void turnVulnerable()
    {
        invincible = false;
    }
}
