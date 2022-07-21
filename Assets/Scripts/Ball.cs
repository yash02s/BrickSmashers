
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public static float initialForce = 600f;
    bool ballStarted;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,initialForce,0));
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if(brick!=null)
        {
            brick.TakeDamage(1);
        }
    }
    public void StartBall()
    {
            if(!ballStarted)
            {
                rb.isKinematic=false;
                // calculate x force
                float xDist = Camera.main.transform.position.x - transform.position.x;
                Debug.Log(xDist);
                rb.AddForce(new Vector3(xDist*43,initialForce,0));
                ballStarted=true;

                transform.SetParent(transform.parent.parent);
            }
    }


    public bool BallStarted()
    {
        return ballStarted;
    }
    public void SetBall()
    {
        ballStarted = true;
    }
}
