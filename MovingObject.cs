using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private bool movingAlong = false;
    private Rigidbody2D rbObject;
    private float objectSpeed=4.0f;


    void Start()
    {
        rbObject = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movingAlong==true){
            Invoke("moveLeft",2.4f);
        }        
        else if(movingAlong==false){
            Invoke("moveRight",2.4f);
        }
    }

    void moveLeft(){
        movingAlong=false;
        rbObject.velocity = new Vector2(-1*objectSpeed, rbObject.velocity.x);
    }

    void moveRight(){
        movingAlong=true;
        rbObject.velocity = new Vector2(1*objectSpeed, rbObject.velocity.x);
    }
}
