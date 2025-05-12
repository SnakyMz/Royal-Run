using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI scoreboardUI;

    int score = 0;

    public void increaseScore(int points)
    {
        score += points;

        scoreboardUI.text = score.ToString();
    }
}
