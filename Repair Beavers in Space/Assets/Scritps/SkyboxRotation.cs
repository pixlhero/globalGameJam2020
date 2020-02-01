using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float RotationSpeed;

    private float rotation;

    private float addedSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        rotation += (RotationSpeed + addedSpeed) * Time.deltaTime ;
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }

    public void SpeedUpShortly()
    {
        DOTween.To(() => addedSpeed, x => addedSpeed = x, 20, 0.5f).OnComplete(() =>
        {
            DOTween.To(() => addedSpeed, x => addedSpeed = x, 0, 3);
        });
    }
}
