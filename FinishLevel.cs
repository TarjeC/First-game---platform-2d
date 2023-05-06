using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
private void OnCollisionEnter2D(Collision2D other){
    if (SceneManager.GetActiveScene().name == "Level 1"){
        if (other.gameObject.name == "player")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
        else if (SceneManager.GetActiveScene().name == "Level 2"){
        if (other.gameObject.name == "player")
        {
            SceneManager.LoadScene("Level 3");
            GameOverScreen.resetCheckPoint();
        }
    }
            else if (SceneManager.GetActiveScene().name == "Level 3"){
        if (other.gameObject.name == "player")
        {
            GameOverScreen.resetCheckPoint();
            SceneManager.LoadScene("Level 4");
        }
    }
}


}
