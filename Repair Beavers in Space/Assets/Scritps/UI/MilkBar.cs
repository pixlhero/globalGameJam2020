using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkBar : MonoBehaviour
{
    public float fillStand;

    public float waveSpeed;

    public RawImage WaveBack;
    public RawImage WaveForward;
    public RectTransform MilkImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rect backUV = WaveBack.uvRect;
        backUV.x += Time.deltaTime * waveSpeed;
        WaveBack.uvRect = backUV;


        Rect forwardUV = WaveForward.uvRect;
        forwardUV.x -= Time.deltaTime * waveSpeed;
        WaveForward.uvRect = forwardUV;

        MilkImage.localScale = new Vector3(1, fillStand, 1);
    }
}
