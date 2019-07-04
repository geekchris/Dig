using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    private double counter;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (counter += Time.deltaTime).ToString("#") + "m";
    }
}
