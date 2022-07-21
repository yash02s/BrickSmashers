using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
public List<GameObject> dropList = new List<GameObject>();

[Range(0,100)]
public int dropChance;

    void Awake()
    {
        instance=this;
    }

    public void DropPowerUp(Vector3 pos)
    {
        int percent = Random.Range(0,101);
        if(percent<=dropChance)
        {
            int index = Random.Range(0,dropList.Count);
            Instantiate(dropList[index],pos,Quaternion.Euler(-90,0,-90));
        }
    }
}
