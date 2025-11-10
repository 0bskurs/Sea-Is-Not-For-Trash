using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Pausa : MonoBehaviour
{
    
    [SerializeField] private Esquiva esquiva;
    [SerializeField] private LifeSystem lifeSystem;
    [SerializeField] ChamarPausa chamarPausa;
    public void resume()
    {
        chamarPausa.calledPause = false;
        esquiva.isOnPause = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(7);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && lifeSystem.died == false)
        {
            chamarPausa.calledPause = false;
            esquiva.isOnPause = false;
            Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync(7);
        }
    }
    
    public static void Open()
    {
        
        SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
    }
    
    public void Principal()
    {
        chamarPausa.calledPause = false;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}
