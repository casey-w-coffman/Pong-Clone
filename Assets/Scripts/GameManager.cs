using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //instance the script
    public static GameManager Instance;

    //enumerate GameState options and define currentState at awake()
    public enum GameState { WaitingToStart, Playing, GameOver }
    public GameState currentState = GameState.WaitingToStart;

    //set left/right score and time to zero, winning score to 11
    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;
    public int time = 0;

    //allows drag/drop text in inspector window for variable
    public GameObject PressSpaceText;
    public GameObject GameOverText;

    void Awake()
    {
        Instance = this;
    }

    //start game if gamestate is waiting to start and space key pressed
    void Update()
    {
        if (currentState == GameState.WaitingToStart && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    //set time limit on game over screen to 10 seconds, then return to start screen
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

    //changes gamestate to playing, sets start screen to inactive, launches the ball
    void StartGame()
    {
        currentState = GameState.Playing;
        PressSpaceText.SetActive(false);
        BallMovement.Instance.LaunchBall();
    }

    //turns off game over screen, on start screen, sets time and scores to zero
    void EndGameOverScreen()
    {
        currentState = GameState.WaitingToStart;
        time = 0;
        leftScore = 0;
        rightScore = 0;
        GameOverText.SetActive(false);
        PressSpaceText.SetActive(true);
    }

    //adds point for left player, checks if score over 11, resets and launches ball if not
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

    //adds point for right player, checks if score over 11, resets and launches ball if not
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