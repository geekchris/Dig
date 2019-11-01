using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    Material material;
    public Vector2 offset;

    public int xVelocity, yVelocity;
    public bool transitionLevel;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        transitionLevel = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if(!transitionLevel)
        {
            material.mainTextureOffset += offset * Time.deltaTime;
        } 
    }
}
