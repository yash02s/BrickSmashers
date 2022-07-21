using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage=10;
    public int speed = 50;
    void Start()
    {
        Destroy(gameObject,1f);
    }
    void Update()
    {
        transform.position+=transform.forward*speed*Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        Brick brick = col.GetComponent<Brick>();
        if(brick!=null)
        {
            brick.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
