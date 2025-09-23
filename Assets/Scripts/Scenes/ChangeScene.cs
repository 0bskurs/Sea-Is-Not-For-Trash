using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(7);
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(7);
        SceneManager.LoadSceneAsync(1);
    }
}
