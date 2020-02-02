using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soundtrack : MonoBehaviour
{

    public float volume = 0.5f;

    public AudioClip gameSound;
    public AudioClip menuSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        source.DOFade(volume, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameSound()
    {
        AudioSource source = GetComponent<AudioSource>();

        source.DOFade(0f, 1).OnComplete(() =>
        {
            source.Stop();
            source.clip = gameSound;
            source.Play();
            source.DOFade(1f, 1);
        });
    }

    public void PlayCalmSound()
    {
        AudioSource source = GetComponent<AudioSource>();

        source.DOFade(0f, 1).OnComplete(() =>
        {
            source.Stop();
            source.clip = menuSound;
            source.Play();
            source.DOFade(0.5f, 1);
        });
    }
}
