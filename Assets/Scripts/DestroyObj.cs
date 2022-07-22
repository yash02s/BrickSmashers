using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public float destroyTime=1;
    void start()
    {
        Destroy(gameObject,destroyTime);
    }

}
