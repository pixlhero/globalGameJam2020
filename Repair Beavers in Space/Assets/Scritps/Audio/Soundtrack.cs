using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soundtrack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();

        source.DOFade(0.7f, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
