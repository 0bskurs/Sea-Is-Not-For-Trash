using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChamarPausa : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public bool calledPause;
    async Task Update()
    {
        if (Time.timeScale != 0 && Input.GetKeyUp(KeyCode.Escape) && lifeSystem.died == false && calledPause == false)
        {
            SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
            Time.timeScale = 0;
            calledPause = true;
        }
        if (Time.timeScale == 0 && Input.GetKeyUp(KeyCode.Escape) && lifeSystem.died == false && calledPause == true)
        {
            calledPause = false;
        }
    }
    
}
