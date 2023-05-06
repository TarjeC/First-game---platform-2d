using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
private Rigidbody2D rb;
private float speed = 7.0f;
private float moveinput;
private float hoppPower=15.0f;
private bool isGrounded = false;
public int groundLayer;
public int spikesLayer;
public int checkpointLayer;
public GameOverScreen GameOverScreen;
private float jumpCounter;
public float jumpTime;
private bool isJumping=false;
private Vector2 angleRayRight;
private Vector2 angleRayLeft;
 bool counting=false;
 float startTime=0;
void Start(){
    groundLayer = LayerMask.GetMask("Ground");
    rb = GetComponent<Rigidbody2D>();
    spikesLayer = LayerMask.GetMask("Spikes");
    checkpointLayer = LayerMask.GetMask("Checkpoint");
}


void Update(){
    jumping();
    moveinput = Input.GetAxisRaw("Horizontal");
}

void groundCheck(){
    angleRayRight=new Vector2(0.5f,-1);
    angleRayLeft=new Vector2(-0.5f,-1);
    RaycastHit2D hit;
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    float distance=0.65f;
    hit = Physics2D.Raycast(rb.position, Vector2.down, distance, groundLayer);
    hitRight = Physics2D.Raycast(rb.position, angleRayRight, 1, groundLayer);
    hitLeft = Physics2D.Raycast(rb.position, angleRayLeft, 1, groundLayer);
    if (hit.collider !=null|| hitRight.collider!=null||hitLeft.collider!=null)
    {
        isGrounded = true;
    }
    else{
        isGrounded=false;
    }
}

void Move(){
    RaycastHit2D hitSpikesUp;
    RaycastHit2D hitSpikesDown;
    hitSpikesDown=Physics2D.Raycast(rb.position, Vector2.down, .75f, spikesLayer);
    hitSpikesUp=Physics2D.Raycast(rb.position, Vector2.up, .75f, spikesLayer);

    if (hitSpikesDown.collider !=null||hitSpikesUp.collider !=null){
    GameOverScreen.Setup();
    Debug.Log("hit spikes loop");
    }
    rb.velocity=new Vector2(moveinput * speed, rb.velocity.y);
    rb.transform.Rotate(0,0,moveinput*1);

}

void jumping(){ 
        groundCheck();
        if (isGrounded){
    if (Input.GetKeyDown(KeyCode.Space))
        {
        jumpCounter=jumpTime;
            rb.velocity=new Vector2(rb.velocity.x, hoppPower);
            isJumping=true;
        }
    }
        if (Input.GetKey(KeyCode.Space)&&isJumping==true)
        {
            if (jumpCounter>0){
            rb.velocity=new Vector2(rb.velocity.x, hoppPower);
            jumpCounter-=Time.deltaTime;
            }else{
                isJumping=false;
            }
        }
            if (Input.GetKeyUp(KeyCode.Space)){
                isJumping=false;
            }
    
}

void gameOverCheck(){
    if (counting==false){
        startTime=Time.time*1000;
    }
    if (rb.position.y<=-30){
        counting=true;
        if ((Time.time*1000)-startTime>=500.0f)
        {
    GameOverScreen.Setup();
    counting=false;
        }
    }
}
private void FixedUpdate(){
    Move();
    gameOverCheck();

}
public void respawnCheck1(){
    rb.transform.position= new Vector3(-5.96f,16.026f,0);
   rb.constraints=RigidbodyConstraints2D.FreezePositionY;
   rb.constraints=RigidbodyConstraints2D.FreezePositionX;
   Invoke("removeFreeze",0.5f);
}
public void respawnCheck2(){
    rb.transform.position= new Vector3(11.3f,23.574f,-0.11f);
   rb.constraints=RigidbodyConstraints2D.FreezePositionY;
   rb.constraints=RigidbodyConstraints2D.FreezePositionX;
   Debug.Log("hitting spikes");
   Invoke("removeFreeze",0.5f);
}

void removeFreeze(){
   rb.constraints=RigidbodyConstraints2D.None;
                
}

public void freezePos(){
    rb.constraints=RigidbodyConstraints2D.FreezePositionY;
    rb.constraints=RigidbodyConstraints2D.FreezePositionX;
     Invoke("removeFreeze",0.5f);

}
}

