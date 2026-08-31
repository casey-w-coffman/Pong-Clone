using UnityEngine;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    public Text leftScoreText;
    public Text rightScoreText;

    void Update()
    {
        leftScoreText.text = GameManager.Instance.leftScore.ToString();
        rightScoreText.text = GameManager.Instance.rightScore.ToString();
    }
}