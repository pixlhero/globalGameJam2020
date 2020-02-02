using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars_rotate : MonoBehaviour
{
    public float speed;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
      //  Invoke("ChangeSpeed", 1);
        //speed = 0.1f;
    }

    void ChangeSpeed()
    {
       // speed = 0.01f;
    }
   
 
    void Update()
    {
        // transform.LookAt(target);
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
