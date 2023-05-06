using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public PlayerScript PlayerScript;
private int checkpoint1Reached;

public void Setup(){
    gameObject.SetActive(true);
    PlayerScript.freezePos();
}
public void resetCheckPoint(){
    checkpoint1Reached=0;
}
public void checkpoint(){
    checkpoint1Reached=1;
}
public void restartButtonLevel1(){
SceneManager.LoadScene("Level 1");
}

public void restartButtonLevel2(){
    SceneManager.LoadScene("Level 2");
    checkpoint1Reached=0;
}
public void restartButtonLevel3(){
    if (checkpoint1Reached==1){
        PlayerScript.respawnCheck1();

    }else{
    SceneManager.LoadScene("Level 3");
    }
        gameObject.SetActive(false);
}
public void restartButtonLevel4(){
    if (checkpoint1Reached==1){
        PlayerScript.respawnCheck2();
    }else{
    SceneManager.LoadScene("Level 4");
    }
        gameObject.SetActive(false);
}

}
