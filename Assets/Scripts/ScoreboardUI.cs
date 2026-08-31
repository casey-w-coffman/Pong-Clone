using UnityEngine;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    //create left/right score text in inspector, drag/drop to define
    public Text leftScoreText;
    public Text rightScoreText;

    //update score based on what is stored in GameManager
    void Update()
    {
        leftScoreText.text = GameManager.Instance.leftScore.ToString();
        rightScoreText.text = GameManager.Instance.rightScore.ToString();
    }
}