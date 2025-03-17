using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject Play_btn;
    
    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        isGameOver = false;
        UpdateScoreDisplay();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        Play_btn.SetActive(false);
    }

    public void AddScore(int points)
    {
        if (isGameOver) return;
        
        score += points;
        UpdateScoreDisplay();
        CheckGameCondition();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = score.ToString();
    }

    private void CheckGameCondition()
    {
        if (score >= 50)
        {
            GameWin();
        }
        else if (score < 0)
        {
            GameLose();
        }
    }

    private void GameWin()
    {
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void GameLose()
    {
        isGameOver = true;
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        score = 0;
        isGameOver = false;
        UpdateScoreDisplay();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
        // Tải lại scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
