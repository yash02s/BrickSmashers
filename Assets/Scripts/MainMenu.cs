using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
   /* public enum MenuStates{Main,Options};
    public MenuStates currentstate;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    void Awake()
    {
        currentstate=MenuStates.Main;
    }
     void Update()
    {
        switch(currentstate)
        {
            case MenuStates.Main:
            {
        GameObject button,button1;
    void Start() 
    {
button = GameObject.Find("Back_button");
button1 = GameObject.Find("Windowed_button");
}
void ButtonClicked() {
button. SetActive(false);
button1. SetActive(false);
    }*?
    
             //mainMenu.SetActive(true);
             //optionsMenu.SetActive(false);
            }
            break;
            case MenuStates.Options:
            { 
             //optionsMenu.SetActive(true);
             mainMenu.SetActive(false);}
            break;
        }}
    
    /*
    }
    public void OnPlay()
    {

    }
    public void OnOptions()
    {
        Debug.Log("Options");
        currentstate=MenuStates.Options;
    }
    public void OnWindowedMode()
    {

    }
    public void OnMainMenu()
    {
        currentstate=MenuStates.Main;
    }*/


    /*public void GoToSettingsMenu()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   }*/



