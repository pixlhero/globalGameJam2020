using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    static ScreenShake instance;
    Vector3 initialPos;

    float shakeTime;

    public AnimationCurve curve;
    public float shakeAmount = 3f;
    public float shakeStrength = 2;
    public float shakeDuration = 0.3f;

    private void Awake()
    {
        instance = this;
        initialPos = transform.position;
        shakeTime = shakeDuration;
    }

    public static void Shake()
    {
        instance.StartShake();
    }
    void StartShake()
    {
        shakeTime = 0;
    }

    private void Update()
    {
        if (shakeTime < shakeDuration)
        {
            shakeTime += Time.deltaTime;

            var pos = initialPos;
            pos.x += curve.Evaluate(shakeTime / shakeDuration) * Mathf.Sin(Time.time * shakeAmount * Mathf.PI * 2) * shakeStrength;

            transform.position = pos;

            if (shakeTime >= shakeDuration)
                transform.position = initialPos;
        }
    }
}
