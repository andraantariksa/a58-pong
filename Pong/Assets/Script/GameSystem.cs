using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // Game Over
    [SerializeField]
    private string gameOverPanelName;
    private GameObject gameOverPanel;
    [SerializeField]
    private string gameOverTextName;
    private Text gameOverText;
    [SerializeField]
    private string gameOverMainMenuButtonName;
    private Button gameOverMainMenuButton;
    [SerializeField]
    private string gameOverWinnerTextName;
    private Text gameOverWinnerText;

    private BallMovement ballMovement;

    void Start()
    {
        ballMovement = GameObject.Find("Ball").GetComponent<BallMovement>();
        
        gameOverPanel = GameObject.Find(gameOverPanelName);
        gameOverPanel.SetActive(false);
        gameOverText = GameObject.Find(gameOverTextName).GetComponent<Text>();
        gameOverText.gameObject.SetActive(false);
        gameOverMainMenuButton = GameObject.Find(gameOverMainMenuButtonName).GetComponent<Button>();
        gameOverMainMenuButton.gameObject.SetActive(false);
        gameOverWinnerText = GameObject.Find(gameOverWinnerTextName).GetComponent<Text>();
        gameOverWinnerText.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void GameOver(string winner)
    {
        gameOverWinnerText.text = string.Format("{0} win the game!", winner);
        gameOverWinnerText.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOverMainMenuButton.gameObject.SetActive(true);

        ballMovement.Stop();
    }
}
