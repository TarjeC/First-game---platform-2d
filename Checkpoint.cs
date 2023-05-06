using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
public GameOverScreen GameOverScreen;
public void OnTriggerEnter2D(Collider2D other){
    GameOverScreen.checkpoint();
}

}
