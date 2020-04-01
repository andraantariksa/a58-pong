using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCollider : MonoBehaviour
{
    [SerializeField]
    private string scorebarName;
    private Text scorebar;
    [SerializeField]
    private string playerName;
    int score = 0;
    private GameSystem gameSystem;
    private BallMovement ballMovement;

    void Start()
    {
        gameSystem = GameObject.Find("EventSystem").GetComponent<GameSystem>();
        ballMovement = GameObject.Find("Ball").GetComponent<BallMovement>();
        scorebar = GameObject.Find(scorebarName).GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D collideWith) {
        if (collideWith.gameObject.name == "Ball")
        {
            AddScore();
        }
    }

    void AddScore()
    {
        score += 1;
        scorebar.text = string.Format("{0:000}", score);

        if (score == 10)
        {
            gameSystem.GameOver(playerName);
        }
        else
        {
            ballMovement.Reset();
        }
    }
}
