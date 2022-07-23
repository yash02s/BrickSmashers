using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelLose4 : MonoBehaviour
{
    public void ReloadLevel_4()
    {
        Debug.Log("Loading");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void BackToMenu_4()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel_4()
    {
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
