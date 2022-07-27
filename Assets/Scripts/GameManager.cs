
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    List<GameObject> ballList = new List<GameObject>();
    List<GameObject> brickList = new List<GameObject>();
    int lifes;
    public Text lifesText;
    
    
    void Awake()
    {
        instance = this;
    }

 void Start()
 {
    ResetGame();
    //Createball();
 }
 void ResetGame()
 {
    lifes = 3;
    Createball();
    UpdateUI();
 }
//-----------------------lifes------------
void UpdateUI(){
   lifesText.text="Lives: " + lifes.ToString("D2");
}

void RemoveLife()
{
    
    lifes--;
    UpdateUI();
    if(lifes==0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
        return ;
    }
    Createball();
    Paddle.instance.ResetPaddle();
}
public void LostBall(GameObject ball)
{
    ballList.Remove(ball);
    Destroy(ball);
    if(ballList.Count==0)
    {
        RemoveLife();
    }
}
//-----------------------brick------------
  public void AddBrick(GameObject brick)
  {
    brickList.Add(brick);
  }
  public void RemoveBrick(GameObject brick)
  {
    brickList.Remove(brick);
    if(brickList.Count==0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
  }


//----------------------------ball-------------------
    void Createball()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position= Paddle.instance.gameObject.transform.position + new Vector3(0,1.5f,0);
        newBall.transform.SetParent(Paddle.instance.gameObject.transform);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;
       
       ballList.Add(newBall);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && ballList.Count>0)
        {
            if(ballList[0]!=null && !ballList[0].GetComponent<Ball>().BallStarted())
            {
                ballList[0].GetComponent<Ball>().StartBall();
            }
        }
    }
    public void Multiball()
    {
        int amount =1;

        for (int i = ballList.Count-1; i >=0; i--)
        {
           Vector3 ballPos = ballList[i].transform.position;  
           if(ballList.Count<=12){
        for (int j = 0; j < amount; j++)
        {
            
        
           GameObject newBall = Instantiate(ballPrefab,ballPos,Quaternion.identity);
           newBall.GetComponent<Rigidbody>().AddForce(Ball.initialForce,Ball.initialForce,0);  
           ballList.Add(newBall);
           newBall.GetComponent<Ball>().SetBall();
        }   }

        }

        
    }
}
