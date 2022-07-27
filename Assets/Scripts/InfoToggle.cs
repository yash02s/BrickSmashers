using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoToggle : MonoBehaviour
{
    public GameObject InfoTo;
    public void OpenPanel()
    {
        if(InfoTo !=null)
        {
            bool isActive=InfoTo.activeSelf;
            InfoTo.SetActive(!isActive);
        }
    }
}
