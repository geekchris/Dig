using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    public Image startButton;
    public Animator Doug;

    public GameObject Logo;
    private bool playingSpin;
    // Start is called before the first frame update

    void Awake()
    {
        startButton.enabled = false;
        playingSpin = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Doug.GetCurrentAnimatorStateInfo(0).IsName("DougMenuSpin") &&
            Doug.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f &&
            startButton.color != Color.white)
        {
            startButton.enabled = true;
            startButton.color = Color.Lerp(startButton.color, Color.white, Mathf.PingPong(Time.time, 0.1f));
        }
    }
    public void StartGame()
    {

        startButton.transform.gameObject.SetActive(false);
        Logo.SetActive(false);
        Doug.Play("DougMenuStart", -1, 0.0f);
    }
}
