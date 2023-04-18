using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseUI;

    public GameObject gameWinUI;


    // Start is called before the first frame update
    void Start()
    {
        EnemyVision.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        FindObjectOfType<CharacterController2D>().OnReachedEndOfLevel += ShowGameWinUI;
    }

    private void GameUI_OnReachedEndOfLevel()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ShowGameWinUI()
    {
        OnGameOver(gameWinUI);
    }

    void ShowGameLoseUI()
    {
        OnGameOver(gameLoseUI);
    }

     void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        
        EnemyVision.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        FindObjectOfType<CharacterController2D>().OnReachedEndOfLevel -= ShowGameWinUI;
    }

     void OnGameWin(GameObject gameWinUI)
     {
       
            gameWinUI.SetActive(true);

     }
}
