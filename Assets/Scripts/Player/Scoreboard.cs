using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text scoreboardUI;

    int score = 0;

    public void IncreaseScore(int points)
    {
        score += points;

        scoreboardUI.text = score.ToString();
    }
}
