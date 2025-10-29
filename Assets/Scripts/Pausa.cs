using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Pausa : MonoBehaviour
{
    private LifeSystem lifeSystem;
    public void resume()
    {
        StartCoroutine(resumeCoroutine());
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && lifeSystem.died == false)
        {
            StartCoroutine(resumeCoroutine());
        }
    }
    private IEnumerator resumeCoroutine()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(7);
        yield return new WaitForSeconds(0.3f);
    }
    public static void Open()
    {
        SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
    }
    
    public void Principal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}
