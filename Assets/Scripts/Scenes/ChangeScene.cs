using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(8);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Creditos()
    {
        SceneManager.LoadSceneAsync(9);
    }
}
