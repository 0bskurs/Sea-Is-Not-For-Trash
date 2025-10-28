using UnityEngine;
using UnityEngine.SceneManagement;
public class ChamarPausa : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale != 0 && Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
}
