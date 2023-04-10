using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    public GameObject minimenuPanel;
    public bool isPaused;

    public void Restart(){

        //Game scene number
        SceneManager.LoadScene(1);
        minimenuPanel.SetActive(false);
    }

    public void mainMenu(){

        //Game scene number
        SceneManager.LoadScene(0);
        minimenuPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(isPaused)
            { 
              CloseMiniMenu();

            }
            else 
            {
              OpenMiniMenu();
            }
        }
    }

    public void OpenMiniMenu(){
        
        Time.timeScale = 0f;
        minimenuPanel.gameObject.SetActive(true);
        isPaused=true;
      
    }
    
    public void CloseMiniMenu(){

        Time.timeScale = 1f;
        minimenuPanel.gameObject.SetActive(false);
        isPaused=false;

    }

}
