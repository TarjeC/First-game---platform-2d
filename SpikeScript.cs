using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public PlayerScript PlayerScript;
    public GameOverScreen GameOverScreen;
public void OnCollisionEnter2D(Collision2D other){
    GameOverScreen.Setup();
    Debug.Log("spike loop");
}
}
