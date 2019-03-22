using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnCLickGameStart()
    {
        SceneManager.LoadScene("GameBase", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
