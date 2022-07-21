using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Ball"))
        {
            GameManager.instance.LostBall(col.gameObject);
        }
        if(col.CompareTag("PowerUp"))
        {
            Destroy(col.gameObject);
        }
    }
}
