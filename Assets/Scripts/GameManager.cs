using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    public GameObject player;
    public enum gameStates { Playing, Death, GameOver };
    public gameStates gameState = gameStates.Playing;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public Text gameOverText;
    void Start()
    {
        if (_gameManager == null)
            _gameManager = gameObject.GetComponent<GameManager>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        gameState = gameStates.Playing;
        // Desactivamos el Canvas gameOver, just in case.
        gameOverCanvas.SetActive(false);
    }
    void Update()
    {
        switch (gameState)
        {
            case gameStates.Playing:
                if (player.GetComponent<PlayerScript>().health == 0)
                {
                    gameState = gameStates.GameOver;
                    StartCoroutine(showGameOverCanvas());
                }
                break;
            case gameStates.GameOver:
                // nothing
                break;
        }
    }

    IEnumerator showGameOverCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void playAgain()
    {
        Debug.Log("PLAY AGAIN CLICKED");
        gameState = gameStates.Playing;
        SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
    }
}
