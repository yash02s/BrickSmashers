using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void Loader1()
    {
        SceneManager.LoadScene("LVL1");
    }
     public void Loader2()
    {
        SceneManager.LoadScene("LVL2");
    } public void Loader3()
    {
        SceneManager.LoadScene("LVL3");
    } public void Loader4()
    {
        SceneManager.LoadScene("LVL4");
    } public void Loader5()
    {
        SceneManager.LoadScene("LVL5");
    }
}
