using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Effects
    {
        MULTIBALL,EXTENT,LASER
    }
    public Effects effect;
   void OnTriggerEnter(Collider col)
   {
      if(col.CompareTag("Player"))
      {
        //apply effect
        ApplyEffect();
        //desrtro
        Destroy(gameObject);
      }
   }

   void ApplyEffect()
   {
    switch(effect)
    {
        case Effects.MULTIBALL:
        {
               GameManager.instance.Multiball();
        }
        break;
        case Effects.LASER:
        {
          Paddle.instance.StartLaserEffect();
        }
        break;
        case Effects.EXTENT:
        {
           Paddle.instance.StartResizeBigger();
        }
        break;
    }
   }
}
