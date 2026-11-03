using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private TMP_Text scoreBoard;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject backToMenuButton;
    private int score = 0;
    private bool gameStart = false;
    void Start()
    {
        Time.timeScale = 1;
        ballRb.gravityScale = 0;
        score = PlayerPrefs.GetInt("AddScore");
        scoreBoard.text = score.ToString();

    }

    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame && !gameStart)
        {
            ballRb.gravityScale = 2;
            gameStart = true;
        }

    }
    public void AddScore()
    {
        score++;
        PlayerPrefs.SetInt("AddScore" ,score);
        scoreBoard.text = score.ToString();

    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Time.timeScale = 0;
            backToMenuButton.SetActive(true);
        }
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Retry()
    {
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
        backToMenuButton.SetActive(false);
        Time.timeScale = 1;
    }
}
