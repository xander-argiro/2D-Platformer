using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI victoryText;

    private void Start()
    {
        victoryText.enabled = false;
    }
    
    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Gems: " + score;
    }

    public void Victory()
    {
        if (score >= 5)
        {
            Debug.Log("buh");
            victoryText.enabled = true;
            Time.timeScale = 0f;
        }
    }
}
