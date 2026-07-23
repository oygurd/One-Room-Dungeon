using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class EscapeMenueManager : MonoBehaviour
{
    InputAction escapeAction;
    public GameObject escapeMenu;
    bool willPause;

    private int changePause;
    
    public GameObject[] UItoDisable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //escapeMenu = GameObject.Find("escape menue UI holder");
        escapeAction = InputSystem.actions.FindAction("ESC");
        changePause = Convert.ToInt32(willPause);
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeAction.triggered)
        {
            willPause = !willPause;
            if (willPause)
            {
                EscContinue(0);
                escapeMenu.SetActive(true);
                Cursor.visible = true;
                
                for (int i = 0; i < UItoDisable.Length; i++)
                {
                    UItoDisable[i].SetActive(false);
                }
            }
            else
            {
                EscContinue(1);
                escapeMenu.SetActive(false);
                Cursor.visible = false;
                
                for (int i = 0; i < UItoDisable.Length; i++)
                {
                    UItoDisable[i].SetActive(true);
                }
            }
            
        }
    }

    public void EscContinue(int scale)
    {
        Time.timeScale = scale;
    }

    public void Continue()
    {
        willPause = !willPause;
        Time.timeScale = 1;
        escapeMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
