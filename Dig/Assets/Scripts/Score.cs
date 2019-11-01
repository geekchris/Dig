using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    private double counter;
    private double boostFactor = 1.0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (counter += Time.deltaTime * boostFactor).ToString("#") + "m";
    }
    public void boostScore()
    {
        boostFactor = 3.0;
    }
    public void normalizeScore()
    {
        boostFactor = 1.0;
    }
}
