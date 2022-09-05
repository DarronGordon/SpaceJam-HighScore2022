using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBG : MonoBehaviour
{
    float startPos;
       float bgLength;
    Camera cam;

    [SerializeField] float parallaxEffect;


    void Start()
    {
        cam=FindObjectOfType<Camera>();
        startPos = transform.position.y;
        bgLength=GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.y*(1-parallaxEffect));

            float distance = (cam.transform.position.y * parallaxEffect);

            
        transform.position = new Vector3(0f,startPos,0f);

        if(temp>startPos + bgLength)
        {
            startPos += bgLength;
        }
        else if(temp<startPos-bgLength)
        {
            startPos-= bgLength;
        }
    }
}
