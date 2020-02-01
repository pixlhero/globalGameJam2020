using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeAnimation : MonoBehaviour
{
    public RectTransform[] RandomTransforms;

    
    public float IntervalLength;

    private float timeSinceLastChange;

    private int lastTransformIndex = 0;


    // Update is called once per frame
    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange > IntervalLength)
        {
            lastTransformIndex++;
            lastTransformIndex %= RandomTransforms.Length;

            this.transform.position = RandomTransforms[lastTransformIndex].position;
            this.transform.rotation = RandomTransforms[lastTransformIndex].rotation;
            this.transform.localScale = RandomTransforms[lastTransformIndex].localScale;

            timeSinceLastChange = 0;


        }

    }
}
