using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float RotationSpeed;

    private float rotation;

    // Update is called once per frame
    void Update()
    {
        rotation += RotationSpeed * Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }
}
