using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { WaitingToStart, Playing, GameOver }
    public GameState currentState = GameState.WaitingToStart;

    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;
    public int time = 0;

    public GameObject PressSpaceText;
    public GameObject GameOverText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (currentState == GameState.WaitingToStart && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    void FixedUpdate()
    {
        if (currentState == GameState.GameOver)
        {
            time++;

            if (time >= 500)
            {
                EndGameOverScreen();
            }
        }
    }

    void StartGame()
    {
        currentState = GameState.Playing;
        PressSpaceText.SetActive(false);
        BallMovement.Instance.LaunchBall();
    }

    void EndGameOverScreen()
    {
        currentState = GameState.WaitingToStart;
        time = 0;
        leftScore = 0;
        rightScore = 0;
        GameOverText.SetActive(false);
        PressSpaceText.SetActive(true);
    }

    public void AddPointLeft()
    {
        leftScore++;

        if (leftScore >= winningScore)
        {
            currentState = GameState.GameOver;
            GameOverText.SetActive(true);
            BallMovement.Instance.ResetBall(false);
        }
        else
        {
            BallMovement.Instance.ResetBall(true);
        }
    }

    public void AddPointRight()
    {
        rightScore++;

        if (rightScore >= winningScore)
        {
            currentState = GameState.GameOver;
            GameOverText.SetActive(true);
            BallMovement.Instance.ResetBall(false);
        }
        else
        {
            BallMovement.Instance.ResetBall(true);
        }
    }
}