using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool isBoosting;
    public Player Doug;

    private float boostCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        isBoosting = false;
        Doug = GameObject.Find("Doug").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isBoosting && boostCount < 6)
        //{
        //    Doug.startBoost();
        //    boostCount += Time.deltaTime;
        //}
        //else
        //{
        //    boostCount = 0;
        //    isBoosting = false;
        //}
    }
}
