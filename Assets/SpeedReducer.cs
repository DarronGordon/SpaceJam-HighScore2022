using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReducer : MonoBehaviour
{


   private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("player")){
    PlayerCtrl.instance.SlowDownBuff();
    Destroy(gameObject);
      }

   }
}
