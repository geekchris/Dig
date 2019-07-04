using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;

    private float shakeAmount = 0;
    private Vector3 originalPos;
    void Awake()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        originalPos = mainCamera.transform.position;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Shake(0.1f, 0.2f);
        }
    }
    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }
    private void BeginShake()
    {
        if(shakeAmount > 0)
        {
            Vector3 camPosition = mainCamera.transform.position;
            float shakeAmountx = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmounty = Random.value * shakeAmount * 2 - shakeAmount;
            camPosition.x += shakeAmountx;
            camPosition.y += shakeAmounty;

            mainCamera.transform.position = camPosition;
        }
    }
    private void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCamera.transform.localPosition = originalPos;
    }
}
