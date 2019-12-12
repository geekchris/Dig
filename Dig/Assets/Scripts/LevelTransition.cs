using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public static int currentlvl = 0;

    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject spawner;
    public GameObject Doug;
    public GameObject levelText;
    private float moveSpeed = 2f;
    private Vector3 pos;
    private Vector3 pos2;
    private Vector3 direction;

    private bool stoppedAllElements;
    public GameObject score;

    public string scoreText;

    public bool isLevelMoving;

    // Start is called before the first frame update
    void Start()
    {
        stoppedAllElements = false;
        isLevelMoving = false;
        if (levelText != null)
        {
            if (currentlvl == 0 && levelText.GetComponent<TextMesh>().text == "Level 1")
            {
                currentlvl = 1;
               
            }
            else if (currentlvl == 0 && levelText.GetComponent<TextMesh>().text == "Level 2")
            {
                currentlvl = 2;
                score.GetComponent<Score>().setCounter(200);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentlvl == 0 && Doug.transform.position.y == -2.0f)
        {
            Debug.Log("in here");
            SceneManager.LoadScene("Level 1");
            currentlvl = 1;
        }
        if (scoreText != null && currentlvl != 0)
        {
            scoreText = score.GetComponent<Score>().scoreText.text.Trim('m');
            if (!scoreText.Equals(""))
            {
                if (currentlvl == 1 && Int32.Parse(scoreText) > 200)
                {
                    //direction.y = (-2f - Doug.transform.position.y);
                    //pos = Doug.transform.position;
                    //Vector3 velocity = new Vector3(0, direction.y, 0) * moveSpeed * Time.deltaTime;
                    //pos += velocity;
                    //Doug.transform.position = pos;
                    if (!stoppedAllElements && !(levelTwo.transform.position.y >= -1.5))
                    {
                        spawner.SetActive(false);
                        isLevelMoving = true;
                        //Debug.Log(levelTwo.transform.position.y);
                        float currentY = levelOne.transform.position.y + 0.2f;
                        float twoY = levelTwo.transform.position.y + 0.1f;
                        //Debug.Log(twoY);
                        pos = levelOne.transform.position;
                        pos2 = levelTwo.transform.position;
                        //Debug.Log(pos2);
                        //Debug.Log(levelTwo.transform.position);
                        //levelOne.GetComponent<BackgroundScroll>().transitionLevel = true;
                        levelTwo.GetComponent<BackgroundScroll>().transitionLevel = true;
                        Vector3 velocity = new Vector3(levelOne.transform.position.x, currentY, levelOne.transform.position.z) * Time.deltaTime;
                        Vector3 velocity2 = new Vector3(levelTwo.transform.position.x, twoY, levelTwo.transform.position.z) * Time.deltaTime;
                        Debug.Log(velocity);
                        Debug.Log(velocity2);
                        pos += velocity;
                        pos2 -= velocity2;
                        //Debug.Log(pos2);
                        levelOne.transform.position = pos;
                        levelTwo.transform.position = pos2;
                        //y += -2;
                    }
                    else
                    {
                        Debug.Log("in here");
                        levelTwo.GetComponent<BackgroundScroll>().transitionLevel = false;
                        GameObject[] ants = GameObject.FindGameObjectsWithTag("Ant");
                        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");

                        if(ants.Length == 0 && rocks.Length == 0)
                        {
                            SceneManager.LoadScene("Level 2");
                            currentlvl = 2;

                        }
                    }
                }
                else if(currentlvl == 2 && Int32.Parse(scoreText) > 210)
                {
                    if (!stoppedAllElements && !(levelTwo.transform.position.y >= -1.5))
                    {
                        spawner.SetActive(false);
                        isLevelMoving = true;
                        //Debug.Log(levelTwo.transform.position.y);
                        float currentY = levelOne.transform.position.y + 0.2f;
                        float twoY = levelTwo.transform.position.y + 0.1f;
                        //Debug.Log(twoY);
                        pos = levelOne.transform.position;
                        pos2 = levelTwo.transform.position;
                        //Debug.Log(pos2);
                        //Debug.Log(levelTwo.transform.position);
                        //levelOne.GetComponent<BackgroundScroll>().transitionLevel = true;
                        levelTwo.GetComponent<BackgroundScroll>().transitionLevel = true;
                        Vector3 velocity = new Vector3(levelOne.transform.position.x, currentY, levelOne.transform.position.z) * Time.deltaTime;
                        Vector3 velocity2 = new Vector3(levelTwo.transform.position.x, twoY, levelTwo.transform.position.z) * Time.deltaTime;
                        Debug.Log(velocity);
                        Debug.Log(velocity2);
                        pos += velocity;
                        pos2 -= velocity2;
                        //Debug.Log(pos2);
                        levelOne.transform.position = pos;
                        levelTwo.transform.position = pos2;
                        //y += -2;
                    }
                    else
                    {
                        Debug.Log("in here");
                        levelTwo.GetComponent<BackgroundScroll>().transitionLevel = false;
                        GameObject[] ants = GameObject.FindGameObjectsWithTag("Ant");
                        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
                        GameObject[] spiders = GameObject.FindGameObjectsWithTag("Spider");
                        if (ants.Length == 0 && rocks.Length == 0 && spiders.Length == 0)
                        {
                            SceneManager.LoadScene("Level 2");
                            currentlvl = 2;

                        }
                    }
                }
            }
        }
    }

    public int getCurrentLvl()
    {
        return currentlvl;
    }
}