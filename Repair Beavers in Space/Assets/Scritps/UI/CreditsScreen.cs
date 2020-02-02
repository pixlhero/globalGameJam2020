using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScreen : UIScreen
{
    public float speed = 1;

    public RawImage CreditsImage;

    public CanvasGroup group;

    public override void Hide()
    {
        SceneManager.LoadScene("UIScene");
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        group.alpha = 0;

        group.DOFade(1, 0.5f);


        Rect uv = CreditsImage.uvRect;
        uv.y = 0.9f;
        CreditsImage.uvRect = uv;

    }

    private void Update()
    {
        Rect uv = CreditsImage.uvRect;
        uv.y -= Time.deltaTime * speed;
        CreditsImage.uvRect = uv;

        if (uv.y < 0.07)
        {
            if (Input.GetButtonDown("Start"))
            {
                Hide();
            }
            uv.y = 0.07f;
            CreditsImage.uvRect = uv;

        }

    }
}
