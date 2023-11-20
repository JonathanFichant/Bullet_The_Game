using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeIntensity;
    private float shakeTimer;
    private Vector3 originalPosition;

    void Start()
    {
        shakeDuration = 0.3f;
        shakeIntensity = 0.4f;
        shakeTimer = 0.0f;
        originalPosition = new Vector3(0.0f, 0.0f, -10.0f);
    }

    void Update()
    {
     
        if (shakeTimer > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    public void StartShake()
    {
        originalPosition = transform.position;
        shakeTimer = shakeDuration;
    }

}
