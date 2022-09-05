using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]GameObject target;
private void FixedUpdate() {
    
Vector3 targetPos = new Vector3(target.transform.position.x,target.transform.position.y+7f,-95f);
 transform.position = Vector3.Lerp(transform.position,targetPos,0.2f);
   
}
}
