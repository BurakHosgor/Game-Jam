using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenuPanel;
    public GameObject HTPPanel;
    
    public AudioSource audioSource;

    public void PlayGame(){

        //Game scene number
        audioSource.volume = 0;
        SceneManager.LoadScene(1);
    }

    public void HowToPlay(){

        mainmenuPanel.SetActive(false);
        HTPPanel.SetActive(true);

    }

    public void BacktoMainMenu(){

        mainmenuPanel.SetActive(true);
        HTPPanel.SetActive(false);

    }

    
    public void Quit(){

        Debug.Log("quitting");
        Application.Quit();
    }

    
}
