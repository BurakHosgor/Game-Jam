using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseUI;

    public GameObject gameWinUI;

    private bool gameIsOver;
    // Start is called before the first frame update
    void Start()
    {
        EnemyVision.OnGuardHasSpottedPlayer += ShowGameLoseUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
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
        gameIsOver=true;
        EnemyVision.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
    }
}
