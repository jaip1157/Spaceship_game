using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //private bool _moving;
    public float movespeed= 1f;
    float speedX,speedY;
    public Rigidbody2D rb2D;

    public bool playerIsAlive=true;

    public LogicScript logic;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
      //_moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
      if(playerIsAlive==true)
      {
        
        speedX= Input.GetAxisRaw("Horizontal")*movespeed;
        speedY= Input.GetAxisRaw("Vertical")*movespeed;
        rb2D.velocity= new Vector2(speedX,speedY);        
      }  
    }
    private void fixedUpdate()
    {
        
      /*  if (_moving){
            _rigidbody.MovePosition(transform.up * movespeed);
        }
      */  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
       //if (collision.gameObject.CompareTag("rock"))
        //{
            logic.gameOver();
            playerIsAlive=false;
            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0f;            
        //}
        
    }
}