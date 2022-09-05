using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    [SerializeField]float horizontalMoveSpeed;
    [SerializeField]float playerSpeed;

    [SerializeField]GameObject gameOverPanel;
    Rigidbody2D rb;
 float pcMove;
 float mobMove ;

 private void Awake() {
    if(instance==null)
    {
        instance=this;
    }
    else{
        Destroy(gameObject);
    }
        DontDestroyOnLoad(gameObject);
 }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        PCMove();
      MobileMove();
        Debug.Log(pcMove);
    }

    private void PlayerMove()
    {
        playerSpeed += Time.deltaTime*.4f;
       // rb.velocity=new Vector2(rb.velocity.x, playerSpeed );
         
         transform.position += transform.up * playerSpeed*Time.deltaTime;
    }

    private void MobileMove()
    {
        mobMove = Input.acceleration.x;
    }

    private void PCMove()
    {
         pcMove = Input.GetAxis("Horizontal");
    }

        private void FixedUpdate() 
     {
     if(mobMove!=0){
      // rb.velocity =new Vector3(mobMove*horizontalMoveSpeed,rb.velocity.y,0);
       transform.Rotate(0f,0f, -mobMove*horizontalMoveSpeed*Time.deltaTime);
     }
     else if(pcMove!=0)
     {
           transform.Rotate(0f,0f,pcMove*horizontalMoveSpeed*Time.deltaTime);
     //   rb.velocity =new Vector3(pcMove*horizontalMoveSpeed,rb.velocity.y,0);
     }
    
   
    }

    public void SlowDownBuff()
    {
        playerSpeed /= 2f;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("planet"))
        {
            GameCtrl.instance.GameOver();
            gameOverPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
