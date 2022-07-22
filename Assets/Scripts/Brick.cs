using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public int score = 50;
    public GameObject particlePrefab;
    void Start()
    {
      // DD THE BRICK TO GAME MANAGER  
      GameManager.instance.AddBrick(gameObject); 
    }
  public void TakeDamage(int amount)
  {
    health-=amount;
    if(health<=0)
    {
        Instantiate(particlePrefab,transform.position,Quaternion.identity);
        GameManager.instance.RemoveBrick(gameObject);
        ScoreManager.instance.AddScore(score);
        PowerUpManager.instance.DropPowerUp(transform.position);
        Destroy(gameObject);
    }
  }
    // Update is called once per frame
    
    
}
