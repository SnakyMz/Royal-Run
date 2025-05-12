using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int score = 0;

    public void IncreaseScore(int points)
    {
        if (gameManager.GameOver) return;

        score += points;

        scoreText.text = score.ToString();
    }
}
