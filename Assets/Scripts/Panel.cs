using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Panel : MonoBehaviour
{
    public void ReloadLevel()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }
}
