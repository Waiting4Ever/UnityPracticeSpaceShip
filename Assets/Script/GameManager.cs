using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    static string SCORE_LABEL = "Score: ";

    public Text scoreText;
    public GameObject gameOverLabel;
    public GameObject retryBtn;
    public GameObject quitBtn;

    int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = SCORE_LABEL + score.ToString();
        gameOverLabel.SetActive(false);
        retryBtn.SetActive(false);
        quitBtn.SetActive(false);
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = SCORE_LABEL + score.ToString();
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene("GameBase", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
