using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelWin5 : MonoBehaviour
{
    public void ReloadLevel_5()
    {
        Debug.Log("Loading");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void BackToMenu_5()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel_5()
    {
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }
}
