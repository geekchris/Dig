using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public GameObject heartOne, heartTwo, heartThree;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Player>().health;
        heartOne.GetComponent<Animator>().speed = 0f;
        heartTwo.GetComponent<Animator>().speed = 0f;
        heartThree.GetComponent<Animator>().speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        playerHealth = player.GetComponent<Player>().health;
        if(playerHealth > 3)
        {
            playerHealth = 3;
        }
        switch (playerHealth)
        {
            case 3:
                heartOne.gameObject.SetActive(true);
                heartTwo.gameObject.SetActive(true);
                heartThree.gameObject.SetActive(true);
                break;
            case 2:
                Debug.Log("2 hearts");
                heartThree.GetComponent<Animator>().speed = 1f;
                break;
            case 1:
                Debug.Log("1 heart");
                heartTwo.GetComponent<Animator>().speed = 1f;
                break;
            case 0:
                Debug.Log("0 hearts");
                heartOne.GetComponent<Animator>().speed = 1f;
                break;
        }
    }
}
