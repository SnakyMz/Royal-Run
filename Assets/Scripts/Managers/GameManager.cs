using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [Header("Game Settings")]
    [SerializeField] float startTime = 30f;

    float timeLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F2");

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
