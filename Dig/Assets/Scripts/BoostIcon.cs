using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostIcon : MonoBehaviour
{
    public Image boostIcon;
    public GameObject _GM;
    private Color c;
    private Color old;
  
    public GameObject Doug;
    public AntObstacle ant;
    public RockObstacle rock;
    public HealthPack health;
    public CameraShake camera;
    public ChargeMeter chargeMeter;
    public Image BoostButton;
    public Score score;
    public BackgroundScroll background;

    private float moveSpeed = 2f;
    private Vector3 pos;
    private Vector3 direction;

    private bool boosting;
    private void Awake()
    {
        c = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        old = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        boosting = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boostIcon.color = Color.Lerp(old, c, Mathf.PingPong(Time.time, 1));

        if(chargeMeter.getSliderValue() == 0.0f && boosting)
        {
            boosting = false;
            background.offset = new Vector2(background.xVelocity, -2);
            score.GetComponent<Score>().normalizeScore();
        }
        if (!boosting && BoostButton.enabled == false)
        {
            direction.y = (3f - Doug.transform.position.y);
            pos = Doug.transform.position;
            Vector3 velocity = new Vector3(0, direction.y, 0) * moveSpeed * Time.deltaTime;
            pos += velocity;
            Doug.transform.position = pos;
        }
        if (boosting)
        {
            direction.y = (-2f - Doug.transform.position.y);
            pos = Doug.transform.position;
            Vector3 velocity = new Vector3(0, direction.y, 0) * moveSpeed * Time.deltaTime;
            pos += velocity;
            Doug.transform.position = pos;
            camera.Shake(0.1f,0.2f);
        }

        if(!boosting && BoostButton.enabled == false && Doug.transform.position.y > 2.99f)
        {
            Doug.GetComponent<Player>().turnVulnerable();
            BoostButton.enabled = true;
            gameObject.SetActive(false);
        }
    }
    public void startBoost()
    {
        boosting = true;
        chargeMeter.DecrementProgress();
        Doug.GetComponent<Player>().turnInvincible();
        score.GetComponent<Score>().boostScore();
        background.offset = new Vector2(background.xVelocity, -5);
        BoostButton.enabled = false;

        rock.isBoosting = true;
        ant.isBoosting = true;
        health.isBoosting = true;
    }
}
