using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject showCreditsGo;
    public bool showCreditsBool;

    private InputAction escapeInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escapeInput = InputSystem.actions.FindAction("ESC");
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeInput.triggered && showCreditsBool)
        {
            showCreditsGo.SetActive(false);
            showCreditsBool = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        showCreditsBool = !showCreditsBool;
        showCreditsGo.SetActive(showCreditsBool);

        if (escapeInput.IsPressed() && showCreditsBool)
        {
            showCreditsGo.SetActive(false);
        }
        
        
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
