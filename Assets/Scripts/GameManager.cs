using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public Button playButton;
    public BallSpawner ballSpawner;
    public Transform playerSpawnPoint;
    public Player player;

    public TextMeshProUGUI gameOverText;
    public Button mainMenuButton;
    public GameObject backgroundPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI congratulationsText;

    private int score = 0;
    private bool isGameActive = false;
    private float timer = 30f;

    private bool isTitleScreen = true;

    void Awake()
    {
        Instance = this;
        ballSpawner.enabled = false;
        mainMenuButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        congratulationsText.gameObject.SetActive(false); 
        backgroundPanel.SetActive(true);

        if (isTitleScreen)
        {
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            titleText.gameObject.SetActive(true);
        }
        else
        {
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            titleText.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0f)
            {
                GameOverCongratulations();
            }
        }
    }

    void StartGame()
    {
        playButton.gameObject.SetActive(false);
        isGameActive = true;
        ResetGame();
        mainMenuButton.gameObject.SetActive(false);

        titleText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);

        backgroundPanel.SetActive(false);

        isTitleScreen = false;
    }

    void ResetGame()
    {
        player.transform.position = playerSpawnPoint.position;
        score = 0;
        timer = 30f;
        UpdateScoreText();
        UpdateTimerText();
        ballSpawner.enabled = true;
    }

    public void AddScore(int points)
    {
        if (isGameActive)
        {
            score += points;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public float GetTimer()
    {
        return timer;
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Round(timer).ToString();
    }

    public void GameOver()
    {
        isGameActive = false;
        ballSpawner.enabled = false;
        gameOverText.text = "Game Over";
        gameOverText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);

        titleText.gameObject.SetActive(isTitleScreen);

        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        backgroundPanel.SetActive(true);
    }

    public void GameOverCongratulations()
    {
        isGameActive = false;
        ballSpawner.enabled = false;

        congratulationsText.text = "Congratulations!";

        congratulationsText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);

        titleText.gameObject.SetActive(isTitleScreen);

        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        backgroundPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public bool IsGameActive()
    {
        return isGameActive;
    }
}
