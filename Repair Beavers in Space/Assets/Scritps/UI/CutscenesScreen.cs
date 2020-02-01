using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutscenesScreen : UIScreen
{
    public Sprite[] cutscenesInOrder;

    public Image CutsceneImage;

    private int currentCutsceneIndex;

    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (TestForNextScene())
        {
            currentCutsceneIndex++;

            if(currentCutsceneIndex >= cutscenesInOrder.Length)
            {
                UIManager.Singleton.SwitchToState(UIManager.UIState.GAME);
            }
            else
            {
                CutsceneImage.sprite = cutscenesInOrder[currentCutsceneIndex];
            }

        }

    }

    private bool TestForNextScene()
    {
        for (int controllerID = 0; controllerID <= 3; controllerID++)
        {
            if (Input.GetButtonDown("Flap " + (controllerID + 1)))
            {
                return true;
            }
        }
        return false;
    }
}
