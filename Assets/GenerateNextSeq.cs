using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNextSeq : MonoBehaviour
{
    [SerializeField]GameObject[] sequences;
float nextseqPosDistance = 370f;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("player"))
        {
            LoadNextSequence();
        }
    }

    private void LoadNextSequence()
    {
      int ranNum = UnityEngine.Random.Range(0, sequences.Length);        
      Vector3 pos = new Vector3 (0f,transform.position.y+nextseqPosDistance,0f);
      Instantiate(sequences[ranNum],pos,Quaternion.identity);
    }


}
