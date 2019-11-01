using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

public class LevelTransition : MonoBehaviour
{
    private int currentlvl;

    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject spawner;
    public GameObject Doug;
    private float moveSpeed = 2f;
    private Vector3 pos;
    private Vector3 pos2;
    private Vector3 direction;

    private bool stoppedAllElements;
    public GameObject score;

    public string scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentlvl = 1;
        stoppedAllElements = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText = score.GetComponent<Score>().scoreText.text.Trim('m');
            if (!scoreText.Equals(""))
            {
                if (currentlvl == 1 && Int32.Parse(scoreText) > 5)
                {
                    //direction.y = (-2f - Doug.transform.position.y);
                    //pos = Doug.transform.position;
                    //Vector3 velocity = new Vector3(0, direction.y, 0) * moveSpeed * Time.deltaTime;
                    //pos += velocity;
                    //Doug.transform.position = pos;
                    if (!stoppedAllElements && !(levelTwo.transform.position.y >= -1.5))
                    {
                        spawner.SetActive(false);
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
                    }
                }
            }
        }
    }
}