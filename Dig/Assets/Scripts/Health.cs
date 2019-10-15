using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public GameObject heartOne, heartTwo, heartThree;
    public int playerHealth;

    private int numHearts;
    public bool playerHealed;

    private Animator animOne, animTwo, animThree;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Player>().health;

        animOne = heartOne.GetComponent<Animator>();
        animOne.speed = 0f;
        animTwo = heartTwo.GetComponent<Animator>();
        animTwo.speed = 0f;
        animThree = heartThree.GetComponent<Animator>();
        animThree.speed = 0f;
        numHearts = 0;
    }

    // Update is called once per frame
    void Update()
    {

        playerHealth = player.GetComponent<Player>().health;
        playerHealed = player.GetComponent<Player>().justHealed;
        if(playerHealth > 3)
        {
            playerHealth = 3;
        }
        if(playerHealed == true)
        {
           
            if(numHearts == 1)
            {
                heartThree.gameObject.SetActive(false);
                animThree.speed = -1f;
                heartThree.gameObject.SetActive(true);
            }  
            else if(numHearts == 2)
            {
                //animTwo.Play("ReverseHeart");
                //animThree.Play("ReverseHeart");

                heartTwo.gameObject.SetActive(false);
                animTwo.speed = -1f;
                heartTwo.gameObject.SetActive(true);
                heartThree.gameObject.SetActive(false);
                animThree.speed = -1f;
                heartThree.gameObject.SetActive(true);
            }
            player.GetComponent<Player>().justHealed = false;
            numHearts = 0;
        }
        else
        {
            switch (playerHealth)
            {
                case 3:
                    heartOne.gameObject.SetActive(true);
                    heartTwo.gameObject.SetActive(true);
                    heartThree.gameObject.SetActive(true);
                    break;
                case 2:
                    animThree.speed = 1f;
                    numHearts = 1;
                    break;
                case 1:
                    animTwo.speed = 1f;
                    numHearts = 2;
                    break;
                case 0:
                    animOne.speed = 1f;
                    break;
            }
        }

    }
}
