using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChargeMeter : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    private ParticleSystem particleSys;
    private Image bar;
    public GameObject boostButton;
    public float FillSpeed = 0.5f;
    public float DepleteSpeed = 0.2f;
    private float targetProgress = 0;

    private bool isBoosting;

    public LevelTransition lvlTransition;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("ChargeParticles").GetComponent<ParticleSystem>();
        bar = GameObject.Find("Fill").GetComponent<Image>();
        isBoosting = false;
    }
    void Start()
    {
        //IncrementProgress(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoosting)
        {
            if(slider.value > targetProgress && slider.value > 0.0f)
            {
                slider.value -= DepleteSpeed * Time.deltaTime;
            }

            if(slider.value == 0.0f)
            {
                isBoosting = false;
                bar.color = Color.red;
            }
        }
        else
        {
            if (slider.value < targetProgress && slider.value < 1.0f)
            {
                slider.value += FillSpeed * Time.deltaTime;
                if (!particleSys.isPlaying)
                    particleSys.Play();
            }
            else
            {
                particleSys.Stop();
            }

            if (slider.value == 1.0f) //&& lvlTransition.isLevelMoving == false)
            {
                bar.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
                boostButton.SetActive(true);

            }
        }
    }

    /**
     * 10/14/19
     * Increment Progress increases the slider value by the 'newProgress' float
     * 
     **/
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
    public void DecrementProgress()
    {
        targetProgress = 0;
        isBoosting = true;
    }
    public float getSliderValue()
    {
        return slider.value;
    }
}
