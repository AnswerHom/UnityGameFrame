using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager<InputManager> {
    private bool isCheckInput = false;

    public InputManager(){
        MonoManager.GetInstance().AddUpdateListener(InputUpdate);
    }

    public void SetCheckInput(bool flag)
    {
        isCheckInput = flag;
    }

    private void InputUpdate()
    {
        if (isCheckInput) return;
        checkInput(KeyCode.W);
        checkInput(KeyCode.S);
        checkInput(KeyCode.A);
        checkInput(KeyCode.D);
    }

    private void checkInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventManager.GetInstance().EventTrigger("按键按下", key);
        }
        if (Input.GetKeyUp(key))
        {
            EventManager.GetInstance().EventTrigger("按键抬起", key);
        }
    }
}
