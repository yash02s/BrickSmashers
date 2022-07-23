using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelLose3 : MonoBehaviour
{
    public void ReloadLevel_3()
    {
        Debug.Log("Loading");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void BackToMenu_3()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel_3()
    {
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
