using UnityEngine;
using UnityEngine.SceneManagement;
public class ChamarPausa : MonoBehaviour
{
    public LifeSystem lifeSystem;
    void Update()
    {
        if (Time.timeScale != 0 && Input.GetKeyUp(KeyCode.Escape) && lifeSystem.died == false)
        {
            SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
}
