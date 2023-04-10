using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject miniMenuCanvas;

    public Animator gameOverAnim;


    public void GameOver(){

        gameOverCanvas.gameObject.SetActive(true);
        miniMenuCanvas.gameObject.SetActive(false);
    }

    public void TryAgain(){

        gameOverCanvas.gameObject.SetActive(false);
        miniMenuCanvas.gameObject.SetActive(true);

        //play UndodeathScreen anim
        gameOverAnim.SetTrigger("gameOver");
        SceneManager.LoadScene(1);
    }
   
   
    public void QuitGame(){

        Debug.Log("quit");
        Application.Quit();
    }
}
