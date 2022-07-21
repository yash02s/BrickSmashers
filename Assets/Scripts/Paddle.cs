using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    public float newSize=2f;
    [Space]
    public GameObject center;
    public GameObject leftCap;
    public GameObject rightCap;
    // Start is called before the first frame update
    Rigidbody rb;
    BoxCollider col;
   

    float speed = 14f;
    bool isScaling;
   // bool isShrinkingToNormal;
   bool isShooting;
   public GameObject bulletPrefab;
   public Transform rSpawnPoint,lSpawnPoint;
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
     rb=GetComponent<Rigidbody>();
     col=GetComponent<BoxCollider>();
     ResetPaddle();
     Resize(newSize);

    }
void Update()
{
    if(isShooting)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab,rSpawnPoint.position,lSpawnPoint.rotation);
             Instantiate(bulletPrefab,lSpawnPoint.position,rSpawnPoint.rotation);
        }
    }
}


    // Update is called once per frame
    void FixedUpdate()
    {
        float h= Input.GetAxisRaw("Horizontal");
        if((int)h==0 && rb.velocity!=Vector3.zero)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;


        }
        else if((int)h !=0){
            rb.isKinematic = false;
        }
        rb.MovePosition(transform.position +new Vector3(h,0,0).normalized*speed*Time.fixedDeltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            float vel = Ball.initialForce;
            Vector3 hitPoint = collision.contacts[0].point;
            float difference = transform.position.x - hitPoint.x;

            if(hitPoint.x<transform.position.x)
            {
                ballRb.AddForce(new Vector3(-(Mathf.Abs(difference*200)),vel,0));
            }
            else
            {
                ballRb.AddForce(new Vector3(Mathf.Abs(difference*200),vel,0));
            }
        }
    }
    void Resize(float xScale)
    {
            Vector3 initScale = center.transform.localScale;
            initScale.x = xScale;
            center.transform.localScale = initScale;

            Vector3 leftCapPos = new Vector3(center.transform.position.x - (xScale/2),leftCap.transform.position.y,leftCap.transform.position.z);
            leftCap.transform.position= leftCapPos;
            Vector3 rightCapPos = new Vector3(center.transform.position.x + (xScale/2),rightCap.transform.position.y,rightCap.transform.position.z);
            rightCap.transform.position= rightCapPos;

            Vector3 colScale = initScale;
            colScale.x+=0.7f*2;
            col.size=colScale;
    }
   public void ResetPaddle()

    {
        transform.position = new Vector3(Camera.main.transform.position.x,transform.position.y,0);
        Resize(newSize);
    }

 IEnumerator ResizePaddle(float goalSize,bool isShrinking)
 {
    if(isScaling)
    {
        yield break;
    }
    isScaling = true;
    if(!isShrinking)
    {
        //resize to normal
        StartCoroutine(ResizeToNormal());
    }
    if(goalSize > col.size.x)
    {
        float currentSize = col.size.x -1.4f;
        while(currentSize > goalSize)
        {
            currentSize -=Time.deltaTime*4;
            Resize(currentSize);
            yield return null;
        }
    }
    else
    { 
        float currentSize = col.size.x -1.4f;
        while(currentSize < goalSize)
        {
            currentSize +=Time.deltaTime*4;
            Resize(currentSize);
            yield return null;
        }
    }
   Resize(goalSize); 

    isScaling = false;
 }

public void StartResizeBigger()
{
    StartCoroutine(ResizePaddle(6,false));
}
public void StartResizeSmaller()
{
    StartCoroutine(ResizePaddle(1,false));
}
IEnumerator ResizeToNormal()
{
    yield return new WaitForSeconds(10);
    StartCoroutine(ResizePaddle(newSize,true));
}
//-------------------------------------Laser------------
IEnumerator ShootingActive()
{
    if(isShooting)
    {
        yield break;
    }
    isShooting = true;
    yield return new WaitForSeconds(10f);
    isShooting = false;
}
public void StartLaserEffect()
{
    StartCoroutine(ShootingActive());
}

}
